﻿// <auto-generated />
using System;
using BS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BS.Infrastructure.Migrations
{
    [DbContext(typeof(BSContext))]
    [Migration("20211124160214_editFields")]
    partial class editFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BS.Domain.AccessCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessCardType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AccessCard");
                });

            modelBuilder.Entity("BS.Domain.AccessCardCredit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessCardCreditType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccessCardId")
                        .HasColumnType("int");

                    b.Property<string>("CostType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CostValue")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccessCardId");

                    b.ToTable("AccessCardCredit");
                });

            modelBuilder.Entity("BS.Domain.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessCardId")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccessCardId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Car");
                });

            modelBuilder.Entity("BS.Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeePosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmplyeeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BS.Domain.ExitGates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("GateId");

                    b.ToTable("ExitGates");
                });

            modelBuilder.Entity("BS.Domain.Gate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GateType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gate");
                });

            modelBuilder.Entity("BS.Domain.AccessCardCredit", b =>
                {
                    b.HasOne("BS.Domain.AccessCard", "AccessCard")
                        .WithMany("AccessCardCredit")
                        .HasForeignKey("AccessCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessCard");
                });

            modelBuilder.Entity("BS.Domain.Car", b =>
                {
                    b.HasOne("BS.Domain.AccessCard", "AccessCard")
                        .WithMany()
                        .HasForeignKey("AccessCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BS.Domain.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessCard");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BS.Domain.ExitGates", b =>
                {
                    b.HasOne("BS.Domain.Car", "Car")
                        .WithMany("ExitGates")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BS.Domain.Gate", "Gate")
                        .WithMany("ExitGates")
                        .HasForeignKey("GateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Gate");
                });

            modelBuilder.Entity("BS.Domain.AccessCard", b =>
                {
                    b.Navigation("AccessCardCredit");
                });

            modelBuilder.Entity("BS.Domain.Car", b =>
                {
                    b.Navigation("ExitGates");
                });

            modelBuilder.Entity("BS.Domain.Gate", b =>
                {
                    b.Navigation("ExitGates");
                });
#pragma warning restore 612, 618
        }
    }
}
