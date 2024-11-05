using System.Reflection;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        
        public DbSet<DaySchedule> DaySchedules { get; set; }
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)));

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });
            
            
            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId }); 
            });
            
            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }); // Definirea cheii primare
            });
            
            /*modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SlotConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new DayScheduleConfiguration());*/

        }
    }
}
