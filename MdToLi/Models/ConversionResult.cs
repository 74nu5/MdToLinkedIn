namespace MdToLi.Models;

/// <summary>
///     Résultat de la conversion Markdown vers texte LinkedIn
/// </summary>
public sealed class ConversionResult
{
    /// <summary>
    ///     Texte brut compatible LinkedIn
    /// </summary>
    public required string LinkedInText { get; set; }

    /// <summary>
    ///     Nombre de caractères du texte LinkedIn
    /// </summary>
    public int CharacterCount { get; set; }

    /// <summary>
    ///     Indique si le texte dépasse le seuil de troncature mobile
    /// </summary>
    public bool IsTruncatedOnMobile { get; set; }

    /// <summary>
    ///     Catégorie visuelle basée sur la longueur (Green, Orange, Red)
    /// </summary>
    public string VisualCategory { get; set; } = "Green";
}
