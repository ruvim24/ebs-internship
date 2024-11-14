/*using Client.Client.Pages;
using Client.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5173") });

builder.Services.AddMudServices();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.AccessDeniedPath = "/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); 
        options.SlidingExpiration = true; 
        options.Cookie.Name = "MyAppCookie"; 
        options.Cookie.HttpOnly = true; 
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; 
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(Client.Client._Imports).Assembly);

app.Run();*/