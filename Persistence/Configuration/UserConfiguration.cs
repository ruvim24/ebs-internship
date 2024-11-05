using Domain.Entities;
using Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            
            builder.HasKey(x => x.Id);

            builder.Property(u => u.FullName)
            .IsRequired() 
            .HasMaxLength(30); 

            /*
            builder.Property(u => u.Password)
                .IsRequired() 
                .HasMaxLength(30);
                */
            
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(30);
            
            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}
