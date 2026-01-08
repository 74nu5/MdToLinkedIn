namespace MdToLi.Services;

using MdToLi.Constants;
using MdToLi.Models;

/// <summary>
/// Service de comptage des caractères avec gestion des seuils visuels
/// </summary>
public sealed class CharacterCounterService
{
    /// <summary>
    /// Compte les caractères et détermine la catégorie visuelle
    /// </summary>
    public ConversionResult CountCharacters(string linkedInText)
    {
        var count = linkedInText.Length;
        var isTruncated = count > LinkedInConstants.MobileTruncationThreshold;
        var category = GetVisualCategory(count);

        return new ConversionResult
        {
            LinkedInText = linkedInText,
            CharacterCount = count,
            IsTruncatedOnMobile = isTruncated,
            VisualCategory = category
        };
    }

    /// <summary>
    /// Détermine la catégorie visuelle selon le nombre de caractères
    /// </summary>
    private static string GetVisualCategory(int characterCount)
    {
        return characterCount switch
        {
            < LinkedInConstants.GreenThreshold => "Green",
            < LinkedInConstants.OrangeThreshold => "Orange",
            _ => "Red"
        };
    }

    /// <summary>
    /// Formatte le nombre de caractères pour affichage
    /// </summary>
    public string FormatCharacterCount(int count)
    {
        return $"{count:N0} / {LinkedInConstants.MaxLinkedInLength:N0} caractères";
    }
}
