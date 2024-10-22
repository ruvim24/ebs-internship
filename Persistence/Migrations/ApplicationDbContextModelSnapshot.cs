﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.DBContext;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Domain.Entitites.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("SlotId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("SlotId")
                        .IsUnique();

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("Domain.Domain.Entitites.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Maker")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Model")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("VIN")
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("Domain.Domain.Entitites.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<int>("MasterId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ServiceType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MasterId")
                        .IsUnique();

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("Domain.Domain.Entitites.Slot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Availability")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MasterId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("Slot", (string)null);
                });

            modelBuilder.Entity("Domain.Domain.Entitites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Schedule.DaySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.ToTable("DaySchedule", (string)null);
                });

            modelBuilder.Entity("Domain.Domain.Entitites.Appointment", b =>
                {
                    b.HasOne("Domain.Domain.Entitites.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Domain.Entitites.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Domain.Entitites.Slot", "Slot")
                        .WithOne()
                        .HasForeignKey("Domain.Domain.Entitites.Appointment", "SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Service");

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("Domain.Domain.Entitites.Car", b =>
                {
                    b.HasOne("Domain.Domain.Entitites.User", "Customer")
                        .WithOne()
                        .HasForeignKey("Domain.Domain.Entitites.Car", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Domain.Entitites.Service", b =>
                {
                    b.HasOne("Domain.Domain.Entitites.User", "Master")
                        .WithOne()
                        .HasForeignKey("Domain.Domain.Entitites.Service", "MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Master");
                });

            modelBuilder.Entity("Domain.Domain.Entitites.Slot", b =>
                {
                    b.HasOne("Domain.Domain.Entitites.User", "Master")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Master");
                });

            modelBuilder.Entity("Domain.Domain.Entitites.User", b =>
                {
                    b.OwnsOne("Domain.Domain.Entitites.User.Email#Domain.Entities.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("integer");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.HasKey("UserId");

                            b1.ToTable("User", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Domain.Domain.Entitites.User.PhoneNumber#Domain.Entities.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("integer");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.HasKey("UserId");

                            b1.ToTable("User", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
