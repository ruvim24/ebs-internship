using Application.Contracts.Commands.Cars.Create;
using Application.Jobs.Cleaner;
using Application.Jobs.Generator;
using Application.Profiles;
using AutoService.ConfigExtensions;
using AutoService.DbSeeder;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
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

var app = builder.Build();

//---CORS
app.UseCors("AllowBlazorClient");


//----Seeding DaySchedule
await app.DayScheduleSeeder();

//----insert all Roles
await app.RoleSeeder();

//----seed the Admin
await app.AdminSeeder();

//-----Set CronJobs
 app.JobsConfiguration();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
