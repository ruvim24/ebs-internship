using API.Client.Pages;
using API.Components;
using Application.Contracts.Commands.Cars.Create;
using Application.Profiles;
using AutoService.ConfigExtensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.DBContext;
using Shared.Validators.Users;

var builder = WebApplication.CreateBuilder(args);


//---CORS
builder.Services.CorsConfiguration();

//---BD
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//--Repositiories and Services
builder.Services.DIConfiguration();

//---MediatR
builder.Services.AddMediatR(typeof(CreateCarCommandHandler).Assembly);
TypeAdapterConfig.GlobalSettings.Scan(typeof(AppointmentMapper).Assembly);

//---FluentValidation
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();

//---Mapper-ul
builder.Services.AddMapster();

//---Hangfire 
builder.Services.HangfireConfiguration();

//Identity Configuration
builder.Services.IdentityConfiguration();

//Cookies
builder.Services.AutentificationCookiesConfiguration();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

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

app.UseOpenApi();
app.UseSwagger();
app.UseSwaggerUi();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(API.Client._Imports).Assembly);

app.Run();