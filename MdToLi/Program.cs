using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MdToLi.Components;
using MdToLi.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configure root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register services
builder.Services.AddScoped<CharacterCounterService>();
builder.Services.AddScoped<MarkdownToLinkedInConverter>();
builder.Services.AddScoped<ThemeService>();
builder.Services.AddScoped<LocalStorageService>();

await builder.Build().RunAsync();
