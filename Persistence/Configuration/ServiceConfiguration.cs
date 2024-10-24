﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Persistence.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");
            
            builder.HasKey(x => x.Id);

            builder.Property(s => s.Name)
            .IsRequired() 
            .HasMaxLength(30);

            builder.Property(s => s.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(s => s.Price)
                .IsRequired(); 

            builder.Property(s => s.Duration)
                .HasConversion<int>()
                .IsRequired();

            // one-to-one with Master
            builder.HasOne(x => x.Master)
                .WithOne()
                .HasForeignKey<Service>(x => x.MasterId);
        }
    }
}
