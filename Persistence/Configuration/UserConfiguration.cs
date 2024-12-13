using Domain.Entities;
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

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(30);
            
            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);
            
            builder.HasIndex(x=>x.Email).IsUnique();
        }
    }
}
