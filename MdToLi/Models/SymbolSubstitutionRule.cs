namespace MdToLi.Models;

public sealed class SymbolSubstitutionRule
{
    public string Pattern { get; set; } = string.Empty;
    public string Replacement { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
