using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.Status)
            .IsRequired(); 


            //one-to-many: Car with Appointment
            builder.HasOne(x => x.Car)
                .WithMany()
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // one to one: appointment with slot
            builder.HasOne(x => x.Slot)
                .WithOne()
                .HasForeignKey<Appointment>(x => x.SlotId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // one to many: service with appointment
            builder.HasOne(x => x.Service)
                .WithMany()
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();


        }
    }
}
