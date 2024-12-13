using Application.Contracts.Commands.Users.SeedAdmin;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence.DataBaseSeeder;
using Shared.Dtos.Users;

namespace API.ConfigExtensions;

public static class Seeder
{
    public static async Task DayScheduleSeeder(this IApplicationBuilder app)
    {
        
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dayScheduleSeeder = scope.ServiceProvider.GetRequiredService<DayScheduleSeeder>();
            await dayScheduleSeeder.SeedAsync(); 
        }
    }

    public static async Task RoleSeeder(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
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
    }

    public static async Task AdminSeeder(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
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
    }
}