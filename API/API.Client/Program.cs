using API.Client.Services;
using Blazr.RenderState.WASM;
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
builder.AddBlazrRenderStateWASMServices();
builder.Services.AddScoped<ISnackbar, SnackbarService>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"));
builder.Services.AddHttpClient("API", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddScoped<AccountService>();

await builder.Build().RunAsync();       