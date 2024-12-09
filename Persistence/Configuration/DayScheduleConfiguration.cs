using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class DayScheduleConfiguration : IEntityTypeConfiguration<DaySchedule>
    {
        public void Configure(EntityTypeBuilder<DaySchedule> builder)
        {
            builder.ToTable("DaySchedule");
            builder.HasKey(x => x.Id);
            
            //indexing
            builder.HasIndex(x => x.DayOfWeek);
        }
    }
}
