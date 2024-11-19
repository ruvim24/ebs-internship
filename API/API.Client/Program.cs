using API.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices(cfg =>
{
    cfg.SnackbarConfiguration.VisibleStateDuration = 5000;
    cfg.SnackbarConfiguration.HideTransitionDuration = 200;
    cfg.SnackbarConfiguration.ShowTransitionDuration = 200;
});

builder.Services.AddScoped<ISnackbar, SnackbarService>();

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AccountService>();

await builder.Build().RunAsync();       