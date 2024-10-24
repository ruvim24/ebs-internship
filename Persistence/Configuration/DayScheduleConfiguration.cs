﻿using Domain.Entities.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    internal class DayScheduleConfiguration : IEntityTypeConfiguration<DaySchedule>
    {
        public void Configure(EntityTypeBuilder<DaySchedule> builder)
        {
            builder.ToTable("DaySchedule");
            builder.HasKey(x => x.Id);
        }
    }
}
