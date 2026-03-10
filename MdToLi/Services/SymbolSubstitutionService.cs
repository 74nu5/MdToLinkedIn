namespace MdToLi.Services;

using System.Net.Http.Json;

using MdToLi.Models;

public sealed class SymbolSubstitutionService
{
    private readonly HttpClient _http;
    private List<SymbolSubstitutionRule>? _rules;

    public SymbolSubstitutionService(HttpClient http)
    {
        _http = http;
    }

    public IReadOnlyList<SymbolSubstitutionRule> Rules => _rules ?? [];

    public async Task LoadAsync()
    {
        if (_rules is not null)
            return;

        try
        {
            var config = await _http.GetFromJsonAsync<ConversionsConfig>("conversions.json");
            _rules = config?.Substitutions ?? [];
        }
        catch
        {
            // Silently fall back to an empty rule set if the file is unavailable
            _rules = [];
        }
    }

    public string Apply(string text)
    {
        if (_rules is null || _rules.Count == 0)
            return text;

        foreach (var rule in _rules)
        {
            if (!string.IsNullOrEmpty(rule.Pattern))
                text = text.Replace(rule.Pattern, rule.Replacement);
        }

        return text;
    }

    private sealed class ConversionsConfig
    {
        public List<SymbolSubstitutionRule> Substitutions { get; set; } = [];
    }
}
