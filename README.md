# [MdToLinkedIn](https://md-to-linkedin.74nu5.dev/)

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?logo=blazor)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)

> Convert Markdown to LinkedIn-compatible Unicode text with real-time preview.

## Overview

LinkedIn doesn't support HTML or rich text formatting in posts. **MdToLinkedIn** solves this by converting your Markdown-formatted text into LinkedIn-friendly plain text using Unicode characters for styling (bold, italic, etc.).

## Features

- **Real-time Conversion** - See your LinkedIn post as you type
- **Unicode Formatting** - Bold, italic, headers, and lists using Unicode characters
- **Character Counter** - Track your post against LinkedIn's 3,000 character limit
- **Mobile Truncation Warning** - Alert when exceeding the ~240 character mobile "see more" threshold
- **One-Click Copy** - Copy formatted text directly to clipboard

## Supported Markdown

| Markdown | LinkedIn Output |
|----------|-----------------|
| `# Title` | 🟦 TITLE |
| `## Subtitle` | 🔹 Subtitle |
| `**bold**` | **𝗯𝗼𝗹𝗱** |
| `*italic*` | *𝘪𝘵𝘢𝘭𝘪𝘤* |
| `- item` | • item |
| `` `code` `` | `code` |

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Run Locally

```bash
# Clone the repository
git clone https://github.com/YOUR_USERNAME/MdToLinkedIn.git
cd MdToLinkedIn

# Run the application
dotnet run --project MdToLi
```

Then open your browser at `https://localhost:5001` (or the URL shown in the console).

### Build for Production

```bash
dotnet publish MdToLi -c Release -o ./publish
```

## Project Structure

```
MdToLinkedIn/
├── MdToLi/                 # Blazor WebAssembly application
│   ├── Components/         # Razor components
│   ├── Services/           # Markdown conversion logic
│   └── wwwroot/            # Static assets
├── MdToLi.slnx             # Solution file
└── README.md
```

## Character Limits

| Range | Status |
|-------|--------|
| < 2,000 | Safe |
| 2,000 - 2,800 | Warning |
| > 2,800 | Near limit |
| > 3,000 | Exceeded |

## Tech Stack

- **Framework**: [Blazor WASM](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- **Language**: C# / .NET 10
- **Hosting**: Client-side only (no backend required)

## Contributing

Contributions are welcome! Feel free to:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Unicode formatting characters from [Unicode Math Alphanumeric Symbols](https://en.wikipedia.org/wiki/Mathematical_Alphanumeric_Symbols)
- Badge icons from [Shields.io](https://shields.io)

---

Made with C# and Blazor
