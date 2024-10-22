using Domain.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class SlotConfiguration : IEntityTypeConfiguration<Slot>
    {
        public void Configure(EntityTypeBuilder<Slot> builder)
        {
            builder.ToTable("Slot");
            
            builder.HasKey(x => x.Id);

            builder.Property(s => s.StartTime)
            .IsRequired(); 

            builder.Property(s => s.EndTime)
                .IsRequired(); 

            builder.Property(s => s.Availability)
                .IsRequired(); 

            //one-to-many relation user with Slot
            builder.HasOne(x => x.Master)
                .WithMany()
                .HasForeignKey(x => x.MasterId)
                .IsRequired();
        }
    }
}
