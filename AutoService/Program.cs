using Application.Contracts.Commands.AppointmentCommands.Create;
using Application.Contracts.Commands.CarCommands.Create;
using Application.Contracts.Commands.CarCommands.Update;
using Application.Contracts.Commands.DayScheduleCommands.Update;
using Application.Contracts.Commands.ServiceCommands.Create;
using Application.Contracts.Commands.UserCommands.Create;
using Application.DTOs.Appointment;
using Application.DTOs.Car;
using Application.DTOs.CarDtos;
using Application.DTOs.DaySchedule;
using Application.DTOs.Service;
using Application.DTOs.UserDtos;
using Application.Validators.AppointmentValidators;
using Application.Validators.CarValidatoros;
using Application.Validators.DaySchedulevalidators;
using Application.Validators.ServiceValidators;
using Application.Validators.UserValidators;
using Domain.DomainServices.AppointmentService;
using Domain.IRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.DBContext;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

//---BD
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//---Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ISlotRepository, SlotRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IDayScheduleRepository, DayScheduleRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

//---Service
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

//---MediatR
builder.Services.AddMediatR(typeof(CreateCarCommandHandler).Assembly);

//---Validators

builder.Services.AddFluentValidation(fv => 
{
    fv.RegisterValidatorsFromAssemblyContaining<CreateCarDtoValidator>();
});

//---Mapper-ul
builder.Services.AddMapster();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
