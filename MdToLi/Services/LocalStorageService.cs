using Microsoft.JSInterop;

namespace MdToLi.Services;

public class LocalStorageService
{
    private readonly IJSRuntime _jsRuntime;
    private const string MarkdownStorageKey = "mdToLinkedIn_markdownText";

    public LocalStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SaveMarkdownAsync(string markdownText)
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", MarkdownStorageKey, markdownText);
        }
        catch (Exception)
        {
            // Silently fail if localStorage is not available
        }
    }

    public async Task<string> LoadMarkdownAsync()
    {
        try
        {
            var result = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", MarkdownStorageKey);
            return result ?? string.Empty;
        }
        catch (Exception)
        {
            // Silently fail if localStorage is not available
            return string.Empty;
        }
    }

    public async Task ClearMarkdownAsync()
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", MarkdownStorageKey);
        }
        catch (Exception)
        {
            // Silently fail if localStorage is not available
        }
    }
}
