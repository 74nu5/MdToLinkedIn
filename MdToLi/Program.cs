using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MdToLi.Components;
using MdToLi.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configure root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HTTP client for loading static assets (e.g. conversions.json)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register services
builder.Services.AddScoped<CharacterCounterService>();
builder.Services.AddScoped<MarkdownToLinkedInConverter>();
builder.Services.AddScoped<ThemeService>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<SymbolSubstitutionService>();

await builder.Build().RunAsync();
