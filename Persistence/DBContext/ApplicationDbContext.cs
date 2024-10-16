﻿using Domain.Domain.Entitites;
using Domain.Entities.ValueObjects.Schedule;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using System.Reflection;

namespace Persistence.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Slot> Slots { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Appointment> Appointments { get; set; }
        DbSet<WeekSchedule> WeekSchedules { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)));

            /*modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SlotConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new DayScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new  WeekScheduleConfiguration());*/


            /*modelBuilder.Entity<DaySchedule>()
                .HasNoKey();*/
        }
    }
}
