using Domain.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>

    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Maker)
            .IsRequired() 
            .HasMaxLength(50); 

            builder.Property(c => c.Model)
                .IsRequired(false) 
                .HasMaxLength(50); 

            builder.Property(c => c.PlateNumber)
                .IsRequired() 
                .HasMaxLength(20); 

            builder.Property(c => c.VIN)
                .IsRequired(false) 
                .HasMaxLength(17);


            //one-to-one reation with Customer
            builder.HasOne(x => x.Customer)
                .WithOne()
                .HasForeignKey<Car>(x => x.CustomerId)
                .IsRequired();
        }
    }
}
