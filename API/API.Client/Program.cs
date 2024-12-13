using API.Client.Services;
using API.Client.Services.Auth;
using Blazr.RenderState.WASM;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
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

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<ServicesService>();
builder.Services.AddScoped<SlotsService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<MasterService>();

builder.Services.AddAuthorizationCore();

builder.Services.AddSingleton<HubConnection>(x =>
    new HubConnectionBuilder()
        .WithUrl("https://localhost:7277/notificationHub")
        .Build());

await builder.Build().RunAsync();       
