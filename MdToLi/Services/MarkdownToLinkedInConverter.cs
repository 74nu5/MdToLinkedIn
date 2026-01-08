namespace MdToLi.Services;

using System.Text.RegularExpressions;

using MdToLi.Models;

/// <summary>
/// Service de conversion Markdown vers texte compatible LinkedIn (Unicode)
/// </summary>
public class MarkdownToLinkedInConverter
{
    private readonly CharacterCounterService _counterService;

    public MarkdownToLinkedInConverter(CharacterCounterService counterService)
    {
        this._counterService = counterService;
    }

    /// <summary>
    /// Convertit du Markdown en texte LinkedIn compatible
    /// </summary>
    public ConversionResult Convert(string markdown)
    {
        if (string.IsNullOrEmpty(markdown))
        {
            return this._counterService.CountCharacters(string.Empty);
        }

        var text = markdown;

        // Appliquer les transformations dans l'ordre approprié
        text = ConvertHeadings(text);
        text = ConvertBold(text);
        text = ConvertItalic(text);
        text = ConvertCodeBlocks(text);
        text = ConvertLists(text);

        // Nettoyer les espaces superflus
        text = NormalizeWhitespace(text);

        return this._counterService.CountCharacters(text);
    }

    /// <summary>
    /// Convertit les titres Markdown (# et ##) en format LinkedIn
    /// </summary>
    private static string ConvertHeadings(string text)
    {
        // ## Titre → 🔹 Titre
        text = Regex.Replace(text, @"^##\s+(.+?)$", "🔹 $1", RegexOptions.Multiline);
        
        // # Titre → 🟦 TITRE
        text = Regex.Replace(text, @"^#\s+(.+?)$", m => $"🟦 {m.Groups[1].Value.ToUpper()}", RegexOptions.Multiline);

        return text;
    }

    /// <summary>
    /// Convertit le gras **texte** en Unicode gras
    /// </summary>
    private static string ConvertBold(string text)
    {
        return Regex.Replace(text, @"\*\*(.+?)\*\*", m => ToBold(m.Groups[1].Value));
    }

    /// <summary>
    /// Convertit l'italique *texte* en Unicode italique
    /// </summary>
    private static string ConvertItalic(string text)
    {
        return Regex.Replace(text, @"\*(.+?)\*", m => ToItalic(m.Groups[1].Value));
    }

    /// <summary>
    /// Convertit les blocs de code inline `code`
    /// </summary>
    private static string ConvertCodeBlocks(string text)
    {
        return Regex.Replace(text, @"`(.+?)`", "`$1`");
    }

    /// <summary>
    /// Convertit les listes - item en • item
    /// </summary>
    private static string ConvertLists(string text)
    {
        return Regex.Replace(text, @"^-\s+", "• ", RegexOptions.Multiline);
    }

    /// <summary>
    /// Normalise les espaces et retours à la ligne superflus
    /// </summary>
    private static string NormalizeWhitespace(string text)
    {
        // Supprimer les espaces inutiles en fin de ligne
        text = Regex.Replace(text, @" +$", "", RegexOptions.Multiline);
        
        // Supprimer les lignes vides multiples (laisser max 1)
        text = Regex.Replace(text, @"\n{3,}", "\n\n");

        return text.Trim();
    }

    /// <summary>
    /// Convertit un texte en gras Unicode
    /// </summary>
    private static string ToBold(string text)
    {
        var boldMap = new Dictionary<char, string>
        {
            { 'A', char.ConvertFromUtf32(0x1D400) }, { 'B', char.ConvertFromUtf32(0x1D401) }, { 'C', char.ConvertFromUtf32(0x1D402) }, { 'D', char.ConvertFromUtf32(0x1D403) }, { 'E', char.ConvertFromUtf32(0x1D404) },
            { 'F', char.ConvertFromUtf32(0x1D405) }, { 'G', char.ConvertFromUtf32(0x1D406) }, { 'H', char.ConvertFromUtf32(0x1D407) }, { 'I', char.ConvertFromUtf32(0x1D408) }, { 'J', char.ConvertFromUtf32(0x1D409) },
            { 'K', char.ConvertFromUtf32(0x1D40A) }, { 'L', char.ConvertFromUtf32(0x1D40B) }, { 'M', char.ConvertFromUtf32(0x1D40C) }, { 'N', char.ConvertFromUtf32(0x1D40D) }, { 'O', char.ConvertFromUtf32(0x1D40E) },
            { 'P', char.ConvertFromUtf32(0x1D40F) }, { 'Q', char.ConvertFromUtf32(0x1D410) }, { 'R', char.ConvertFromUtf32(0x1D411) }, { 'S', char.ConvertFromUtf32(0x1D412) }, { 'T', char.ConvertFromUtf32(0x1D413) },
            { 'U', char.ConvertFromUtf32(0x1D414) }, { 'V', char.ConvertFromUtf32(0x1D415) }, { 'W', char.ConvertFromUtf32(0x1D416) }, { 'X', char.ConvertFromUtf32(0x1D417) }, { 'Y', char.ConvertFromUtf32(0x1D418) },
            { 'Z', char.ConvertFromUtf32(0x1D419) },
            { 'a', char.ConvertFromUtf32(0x1D41A) }, { 'b', char.ConvertFromUtf32(0x1D41B) }, { 'c', char.ConvertFromUtf32(0x1D41C) }, { 'd', char.ConvertFromUtf32(0x1D41D) }, { 'e', char.ConvertFromUtf32(0x1D41E) },
            { 'f', char.ConvertFromUtf32(0x1D41F) }, { 'g', char.ConvertFromUtf32(0x1D420) }, { 'h', char.ConvertFromUtf32(0x1D421) }, { 'i', char.ConvertFromUtf32(0x1D422) }, { 'j', char.ConvertFromUtf32(0x1D423) },
            { 'k', char.ConvertFromUtf32(0x1D424) }, { 'l', char.ConvertFromUtf32(0x1D425) }, { 'm', char.ConvertFromUtf32(0x1D426) }, { 'n', char.ConvertFromUtf32(0x1D427) }, { 'o', char.ConvertFromUtf32(0x1D428) },
            { 'p', char.ConvertFromUtf32(0x1D429) }, { 'q', char.ConvertFromUtf32(0x1D42A) }, { 'r', char.ConvertFromUtf32(0x1D42B) }, { 's', char.ConvertFromUtf32(0x1D42C) }, { 't', char.ConvertFromUtf32(0x1D42D) },
            { 'u', char.ConvertFromUtf32(0x1D42E) }, { 'v', char.ConvertFromUtf32(0x1D42F) }, { 'w', char.ConvertFromUtf32(0x1D430) }, { 'x', char.ConvertFromUtf32(0x1D431) }, { 'y', char.ConvertFromUtf32(0x1D432) },
            { 'z', char.ConvertFromUtf32(0x1D433) }
        };

        return string.Concat(text.Select(c => boldMap.ContainsKey(c) ? boldMap[c] : c.ToString()));
    }

    /// <summary>
    /// Convertit un texte en italique Unicode
    /// </summary>
    private static string ToItalic(string text)
    {
        var italicMap = new Dictionary<char, string>
        {
            { 'A', char.ConvertFromUtf32(0x1D434) }, { 'B', char.ConvertFromUtf32(0x1D435) }, { 'C', char.ConvertFromUtf32(0x1D436) }, { 'D', char.ConvertFromUtf32(0x1D437) }, { 'E', char.ConvertFromUtf32(0x1D438) },
            { 'F', char.ConvertFromUtf32(0x1D439) }, { 'G', char.ConvertFromUtf32(0x1D43A) }, { 'H', char.ConvertFromUtf32(0x1D43B) }, { 'I', char.ConvertFromUtf32(0x1D43C) }, { 'J', char.ConvertFromUtf32(0x1D43D) },
            { 'K', char.ConvertFromUtf32(0x1D43E) }, { 'L', char.ConvertFromUtf32(0x1D43F) }, { 'M', char.ConvertFromUtf32(0x1D440) }, { 'N', char.ConvertFromUtf32(0x1D441) }, { 'O', char.ConvertFromUtf32(0x1D442) },
            { 'P', char.ConvertFromUtf32(0x1D443) }, { 'Q', char.ConvertFromUtf32(0x1D444) }, { 'R', char.ConvertFromUtf32(0x1D445) }, { 'S', char.ConvertFromUtf32(0x1D446) }, { 'T', char.ConvertFromUtf32(0x1D447) },
            { 'U', char.ConvertFromUtf32(0x1D448) }, { 'V', char.ConvertFromUtf32(0x1D449) }, { 'W', char.ConvertFromUtf32(0x1D44A) }, { 'X', char.ConvertFromUtf32(0x1D44B) }, { 'Y', char.ConvertFromUtf32(0x1D44C) },
            { 'Z', char.ConvertFromUtf32(0x1D44D) },
            { 'a', char.ConvertFromUtf32(0x1D44E) }, { 'b', char.ConvertFromUtf32(0x1D44F) }, { 'c', char.ConvertFromUtf32(0x1D450) }, { 'd', char.ConvertFromUtf32(0x1D451) }, { 'e', char.ConvertFromUtf32(0x1D452) },
            { 'f', char.ConvertFromUtf32(0x1D453) }, { 'g', char.ConvertFromUtf32(0x1D454) }, { 'h', char.ConvertFromUtf32(0x1D455) }, { 'i', char.ConvertFromUtf32(0x1D456) }, { 'j', char.ConvertFromUtf32(0x1D457) },
            { 'k', char.ConvertFromUtf32(0x1D458) }, { 'l', char.ConvertFromUtf32(0x1D459) }, { 'm', char.ConvertFromUtf32(0x1D45A) }, { 'n', char.ConvertFromUtf32(0x1D45B) }, { 'o', char.ConvertFromUtf32(0x1D45C) },
            { 'p', char.ConvertFromUtf32(0x1D45D) }, { 'q', char.ConvertFromUtf32(0x1D45E) }, { 'r', char.ConvertFromUtf32(0x1D45F) }, { 's', char.ConvertFromUtf32(0x1D460) }, { 't', char.ConvertFromUtf32(0x1D461) },
            { 'u', char.ConvertFromUtf32(0x1D462) }, { 'v', char.ConvertFromUtf32(0x1D463) }, { 'w', char.ConvertFromUtf32(0x1D464) }, { 'x', char.ConvertFromUtf32(0x1D465) }, { 'y', char.ConvertFromUtf32(0x1D466) },
            { 'z', char.ConvertFromUtf32(0x1D467) }
        };

        return string.Concat(text.Select(c => italicMap.ContainsKey(c) ? italicMap[c] : c.ToString()));
    }
}
