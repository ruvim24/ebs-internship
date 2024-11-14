using Domain.DomainServices.AppointmentService;
using Domain.DomainServices.SlotGeneratorService;
using Domain.Entities;
using Domain.IRepositories;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Persistence.DataBaseSeeder;
using Persistence.DBContext;
using Persistence.Repositories;

namespace API.ConfigExtensions;

public static class ServiceExtension
{
    public static IServiceCollection IdentityConfiguration(this IServiceCollection services)
    {
            
            services.AddIdentity<User, IdentityRole<int>>(options =>
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
            
            return services;
    }

    public static IServiceCollection AutentificationCookiesConfiguration(this IServiceCollection services)
    {
        
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "auth_token"; 
                options.Cookie.HttpOnly = true; 
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 
                options.Cookie.SameSite = SameSiteMode.Strict; 
                options.LoginPath = "/Account/login"; 
                options.LogoutPath = "/Account/logout"; 
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
            });
        return services;
    }
    
    public static IServiceCollection HangfireConfiguration(this IServiceCollection services)
    {
        
        services.AddHangfire(config =>
        {
            var connectionString = services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");

            config.UsePostgreSqlStorage(connectionString, new PostgreSqlStorageOptions
            {
                SchemaName = "hangfire",
                DistributedLockTimeout = TimeSpan.FromMinutes(1)
            });
        });
        services.AddHangfireServer();

        return services;
    }

    public static IServiceCollection DIConfiguration(this IServiceCollection services)
    {
        
        //---Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ISlotRepository, SlotRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IDayScheduleRepository, DayScheduleRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();

        //---Service
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<ISlotService, SlotService>();
        
        
        //---DayScheduleSeeder
        services.AddTransient<DayScheduleSeeder>();

        return services;
    }

    /*public static IServiceCollection CorsConfiguration(this IServiceCollection services)
    {*/
        
        /*services.AddCors(options =>
        {
            options.AddPolicy("AllowBlazorClient", builder =>
            {
                builder.WithOrigins("http://localhost:5095") 
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        return services;*/
    /*/*#1#}*/
}