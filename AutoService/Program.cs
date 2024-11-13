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
    
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
