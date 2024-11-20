using API;
using API.Client.Services;
using API.Components;
using API.ConfigExtensions;
using Application.Contracts.Commands.Cars.Create;
using Application.Profiles;
using Blazr.RenderState.Server;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using Persistence.DBContext;
using Shared.Validators.Users;
using _Imports = API.Client._Imports;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorComponents()   
    .AddInteractiveWebAssemblyComponents();


builder.Services.AddMudServices(cfg =>
{
    cfg.SnackbarConfiguration.VisibleStateDuration = 5000;
    cfg.SnackbarConfiguration.HideTransitionDuration = 200;
    cfg.SnackbarConfiguration.ShowTransitionDuration = 200;
});
builder.AddBlazrRenderStateServerServices();
builder.Services.AddScoped<ISnackbar, SnackbarService>();


//---DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//--Repositiories and Services
builder.Services.DIConfiguration();

//---MediatR
builder.Services.AddMediatR(typeof(CreateCarCommandHandler).Assembly);
TypeAdapterConfig.GlobalSettings.Scan(typeof(AppointmentMapper).Assembly);

//---Mapper-ul
// Adaugă Mapster în DI
/*
builder.Services.AddSingleton<IMapper, Mapper>();
*/
builder.Services.AddMapster();

//---FluentValidation
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();

//---Hangfire 
builder.Services.HangfireConfiguration();

//Identity Configuration
builder.Services.AddHttpContextAccessor();

builder.Services.IdentityConfiguration();

//Cookies
builder.Services.AutentificationCookiesConfiguration();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*
builder.Services.AddCascadingAuthenticationState();
*/

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

//----Seeding DaySchedule
await app.DayScheduleSeeder();

//----insert all Roles
await app.RoleSeeder();

//----seed the Admin
await app.AdminSeeder();

//-----Set CronJobs
app.JobsConfiguration();


app.UseOpenApi();
app.UseSwagger();
app.UseSwaggerUi();

/*
app.UseMiddleware<RedirectIfUnauthorizedMiddleware>(); //rederection to login page
*/

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(_Imports).Assembly);

app.Run();