using Domain.Domain.Entitites;
using Domain.Entities.ValueObjects.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    internal class WeekScheduleConfiguration : IEntityTypeConfiguration<WeekSchedule>

    {
        public void Configure(EntityTypeBuilder<WeekSchedule> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasMany(ws => ws.DaySchedules) 
           .WithOne(ds => ds.WeekSchedule) 
           .HasForeignKey(ds => ds.WeekScheduleId) 
           .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
