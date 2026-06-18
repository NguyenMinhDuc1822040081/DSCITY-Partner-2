using DSCITYPartner.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<PartnerPortalService>();
builder.Services.AddSingleton<PartnerAuthService>();
builder.Services.AddSingleton<AccountDirectory>();
builder.Services.AddSingleton<LanguageService>();

await builder.Build().RunAsync();
