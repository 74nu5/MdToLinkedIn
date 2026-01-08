# Project Context for Claude

## Project Overview

**MdToLinkedIn** - A Blazor application that converts Markdown text to LinkedIn-compatible plain text with Unicode formatting.

## Purpose

LinkedIn doesn't support HTML or rich text formatting. This application helps users write posts in Markdown and converts them to LinkedIn-friendly plain text using Unicode characters for formatting (bold, italic, etc.).

## Key Features

1. **Markdown Editor** - Simple textarea for Markdown input
2. **Real-time Conversion** - Converts Markdown to LinkedIn-compatible Unicode text
3. **Character Counter** - Tracks character count against LinkedIn's 3,000 character limit
4. **Mobile Truncation Warning** - Alerts when post exceeds ~240 characters (mobile "see more" threshold)
5. **Copy to Clipboard** - Easy copy functionality for pasting into LinkedIn

## Technology Stack

- **Framework**: Blazor (C#/.NET)
- **UI Components**: Custom Blazor components
- **No external dependencies** for Markdown parsing (simple custom parser)

## Markdown Support (Limited Subset)

- Headers: `#`, `##`
- Bold: `**text**`
- Italic: `*text*`
- Lists: `- item`
- Inline code: `` `code` ``

## Conversion Rules

| Markdown | LinkedIn Output |
|----------|----------------|
| `# Title` | `🟦 TITLE` |
| `## Title` | `🔹 Title` |
| `**text**` | `𝗧𝗲𝘅𝘁` (Unicode bold) |
| `*text*` | `𝘐𝘁𝘢𝘭𝘪𝘤` (Unicode italic) |
| `- item` | `• item` |

## Key Constants

```csharp
MaxLinkedInLength = 3000
MobileTruncationThreshold = 240
```

## Character Counter Thresholds

- **< 2,000 chars**: Green (safe)
- **2,000 - 2,800 chars**: Orange (warning)
- **> 2,800 chars**: Red (near limit)

## Main Components

- `MarkdownInput` - Markdown editor component
- `LinkedInPreview` - Preview of converted text
- `CharacterCounter` - Character count display
- `MobileTruncationWarning` - Mobile truncation alert
- `CopyButton` - Copy to clipboard functionality

## Project Structure

```
MdToLinkedIn/
├── conception_markdown_vers_linked_in_blazor.md (design doc in French)
├── MdToLi/ (Blazor application folder)
└── MdToLi.slnx (solution file)
```

## Out of Scope (V1)

- LinkedIn authentication
- Automatic posting to LinkedIn
- Post storage/history
- Exact LinkedIn preview rendering

## Future Enhancements (Ideas)

- Post templates
- Hook/opener optimization
- Thread mode
- Export to TXT/MD
- Dark mode

## Design Philosophy

- **Simplicity first** - Minimal feature set
- **Maximum LinkedIn compatibility** - Plain text Unicode only
- **Mobile-first mindset** - Emphasis on mobile truncation awareness
- **Quick implementation** - Small, maintainable codebase

## Language Note

The design document (`conception_markdown_vers_linked_in_blazor.md`) is in French. The codebase should use English for identifiers and comments unless otherwise specified by the user.

## Development Notes

- This is a client-side only application
- No backend/API required
- All conversion happens in the browser
- No data persistence (stateless)
