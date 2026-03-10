# Copilot Instructions

## Build & Run

```bash
# Run locally (open browser at the URL shown in console)
dotnet run --project MdToLi

# Build
dotnet build

# Production publish
dotnet publish MdToLi -c Release -o ./publish
```

The project targets **net9.0** (Blazor WebAssembly). No test project exists.

Deployment is automatic via GitHub Actions to **Azure Static Web Apps** on push to `master`.

## Architecture

Single Blazor WASM project (`MdToLi/`) — purely client-side, no backend.

**Data flow for conversion:**
```
Home.razor
  → MarkdownToLinkedInConverter.Convert(markdown)
      → ConvertHeadings → ConvertBold → ConvertItalic → ConvertCodeBlocks → ConvertLists → NormalizeWhitespace
      → CharacterCounterService.CountCharacters(text)
  ← ConversionResult { LinkedInText, CharacterCount, IsTruncatedOnMobile, VisualCategory }
```

**Services** (all registered as `Scoped` in `Program.cs`):
- `MarkdownToLinkedInConverter` — stateless regex-based Markdown parser; depends on `CharacterCounterService`
- `CharacterCounterService` — builds `ConversionResult` with character count and visual category (Green/Orange/Red)
- `LocalStorageService` — persists markdown text via `IJSRuntime` with key `mdToLinkedIn_markdownText`; all methods silently swallow exceptions
- `ThemeService` — in-memory light/dark theme with `OnThemeChanged` event; initialized from a saved value passed in from JS

**JS interop:**
- `MarkdownInput.razor.js` is loaded as an **ES module** (`import` via `IJSRuntime.InvokeAsync<IJSObjectReference>`) to get/set textarea selection state
- `CopyButton.razor` uses `navigator.clipboard.writeText` directly
- `LocalStorageService` calls `localStorage.setItem/getItem/removeItem` directly

## Key Conventions

**Language split:** UI-facing strings (labels, placeholders, messages) are in **French**. Code identifiers, inline comments, and new code should use **English**.

**Conversion pipeline order matters:** `##` headings must be processed before `#` headings to prevent the `#` regex from matching `##` lines. Never reorder these steps.

**Unicode character mapping:** Bold uses U+1D400–U+1D433 (Mathematical Bold), italic uses U+1D434–U+1D467 (Mathematical Italic). These are **surrogate pairs** — each mapped character is 2 `char` units in C#. Only A–Z and a–z are mapped; digits, spaces, punctuation, and accented characters pass through unchanged.

**Character count caveat:** `CharacterCount` uses `string.Length`, which counts surrogate pairs as 2. Heavily formatted text will count higher than the visible character count.

**`ConversionResult` is the central model** returned by every conversion. It bundles the converted text together with all metadata needed by the UI (count, truncation flag, visual category).

**Constants** live in `MdToLi.Constants.LinkedInConstants`. All thresholds and limits go there.

**Toolbar formatting** in `MarkdownInput.razor` wraps/unwraps selection in Markdown syntax by manipulating raw string positions — it does not re-parse the document. The pattern for toolbar buttons: call `GetSelectionInfo()` (JS interop), manipulate string, invoke `MarkdownTextChanged`, then `SetSelection()`.

**`OnAfterRenderAsync(firstRender)`** in `Home.razor` is used to load from `LocalStorage` — this is required because JS interop is not available during `OnInitializedAsync` in WASM.
