//using Application.Jobs.Extension;

using Application.Contracts.Commands.Cars.Create;
using Application.Contracts.Commands.Users.SeedAdmin;
using Application.DTOs.Users;
using Application.Jobs.Configuration;
using Application.Profiles;
using Application.Validators.Users;
using Domain.DomainServices.AppointmentService;
using Domain.Entities;
using Domain.IRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
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


//Identity Configuration
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders(); 

//Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token"; 
        options.Cookie.HttpOnly = true; 
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 
        options.Cookie.SameSite = SameSiteMode.Strict; 
        options.LoginPath = "/Account/Login"; 
        options.LogoutPath = "/Account/Logout"; 
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    });


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

//insert all Roles

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    var roles = new string[] { "Admin", "Customer", "Master" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole<int>(role));
        }
    }
};

//seed the Admin
using (var scope = app.Services.CreateScope())
{
    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

  
    var command = new SeedAdminCommand(new AdminCreateDto
    {
        FullName = "Admin",
        Email = "admin@gmail.com", 
        Password = "Admin.1234",
        Username = "admin@gmail.com",
        PhoneNumber = "+35912345678"
    });

    var result = await mediator.Send(command);

    if (result.IsSuccess)
    {
        Console.WriteLine("Admin user created successfully.");
    }
    else
    {
        Console.WriteLine("Error: " + result.Errors.FirstOrDefault()?.Message);
    }
}


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
