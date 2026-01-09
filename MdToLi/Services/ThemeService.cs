namespace MdToLi.Services;

public class ThemeService
{
    private const string ThemeKey = "theme-preference";
    private string _currentTheme = "light";

    public event Action? OnThemeChanged;

    public string CurrentTheme => _currentTheme;
    public bool IsDarkMode => _currentTheme == "dark";

    public void SetTheme(string theme)
    {
        if (theme != "light" && theme != "dark")
        {
            throw new ArgumentException("Theme must be 'light' or 'dark'", nameof(theme));
        }

        _currentTheme = theme;
        OnThemeChanged?.Invoke();
    }

    public void ToggleTheme()
    {
        _currentTheme = _currentTheme == "light" ? "dark" : "light";
        OnThemeChanged?.Invoke();
    }

    public void InitializeTheme(string? savedTheme)
    {
        if (!string.IsNullOrEmpty(savedTheme) && (savedTheme == "light" || savedTheme == "dark"))
        {
            _currentTheme = savedTheme;
        }
        else
        {
            _currentTheme = "light";
        }
    }
}
