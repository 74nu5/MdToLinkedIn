namespace MdToLi.Constants;

/// <summary>
/// Constantes de configuration pour la conversion Markdown → LinkedIn
/// </summary>
public static class LinkedInConstants
{
    /// <summary>
    /// Longueur maximale autorisée pour un post LinkedIn
    /// </summary>
    public const int MaxLinkedInLength = 3000;

    /// <summary>
    /// Seuil approximatif de troncature sur mobile (2-3 lignes visibles)
    /// </summary>
    public const int MobileTruncationThreshold = 240;

    /// <summary>
    /// Seuil de caractères pour passer au vert (< 2000)
    /// </summary>
    public const int GreenThreshold = 2000;

    /// <summary>
    /// Seuil de caractères pour passer à l'orange (2000 - 2800)
    /// </summary>
    public const int OrangeThreshold = 2800;

    /// <summary>
    /// Caractères Unicode pour les titres et listes
    /// </summary>
    public static class UnicodeChars
    {
        public const string BoldPrefix = "𝗕";
        public const string ItalicPrefix = "𝘐";
        public const string H1Emoji = "🟦";
        public const string H2Emoji = "🔹";
        public const string BulletPoint = "•";
    }
}
