using Domain.Domain.Entitites;
using Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.FullName)
            .IsRequired() 
            .HasMaxLength(30); 

            builder.Property(u => u.Password)
                .IsRequired() 
                .HasMaxLength(30);

            /*builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);*/

            builder.OwnsOne(x => x.Email, email => 
              email.Property(c => c.Value).IsRequired().HasMaxLength(50));
              

            /*builder.Property(u => u.PhoneNumber)
                .IsRequired(false);*/

            builder.OwnsOne(x => x.PhoneNumber, phoneBuilder =>
             phoneBuilder.Property(c => c.Value).IsRequired().HasMaxLength(50));

            builder.Property(u => u.Role)
                .IsRequired(); 

            // one to one: user - service
            builder.HasOne(x => x.Service)
                .WithOne(x => x.Master)
                .HasForeignKey<User>(x => x.ServiceId)
                .IsRequired(false);


        }
    }
}
