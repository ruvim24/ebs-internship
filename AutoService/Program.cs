using Application.Contracts.Commands.Cars.Create;
using Application.Jobs.Cleaner;
using Application.Jobs.Generator;
using Application.Profiles;
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

/*
//---CORS
app.UseCors("AllowBlazorClient");
*/



if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();



app.Run();
