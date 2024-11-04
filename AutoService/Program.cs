//using Application.Jobs.Extension;
using Application.Contracts.Commands.Cars.Create;
using Application.Jobs.Cleaner;
using Application.Jobs.Configuration;
using Application.Jobs.Generator;
using Application.Profiles;
using Application.Validators.Users;
using Application.Validators.UserValidators;
using Domain.DomainServices.AppointmentService;
using Domain.DomainServices.SlotGeneratorService;
using Domain.IRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.DataBaseSeeder;
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
/*
builder.Services.AddScoped<ISlotService, SlotService>();
*/

//----DataBaseSeeder
builder.Services.AddTransient<DayScheduleSeeder>();

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
/*
builder.Services.ConfigureHangfire(builder.Configuration.GetConnectionString("DefaultConnection"));
*/

builder.Services.ConfigureQuartzJobs();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*
app.ConfigureHangfireJobs();
*/

//Seeding DaySchedule
using (var scope = app.Services.CreateScope())
{
    var dayScheduleSeeder = scope.ServiceProvider.GetRequiredService<DayScheduleSeeder>();
    await dayScheduleSeeder.SeedAsync(); 
}



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
