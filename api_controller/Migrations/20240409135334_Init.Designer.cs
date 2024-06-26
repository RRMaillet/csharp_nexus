﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_controller.Data;

#nullable disable

namespace api_controller.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240409135334_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api_controller.Models.Floor", b =>
                {
                    b.Property<int>("FloorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FloorId"));

                    b.Property<string>("FloorColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FloorDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FloorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("FloorId");

                    b.ToTable("Floors");

                    b.HasData(
                        new
                        {
                            FloorId = 12,
                            FloorColor = "Beige",
                            FloorDescription = "Beige Laminate Floor",
                            FloorName = "Laminate",
                            Price = 1.53
                        },
                        new
                        {
                            FloorId = 15,
                            FloorColor = "Brown",
                            FloorDescription = "Brown Cork Floor",
                            FloorName = "Cork",
                            Price = 2.1000000000000001
                        },
                        new
                        {
                            FloorId = 18,
                            FloorColor = "Black",
                            FloorDescription = "Black Leather Floor",
                            FloorName = "Leather",
                            Price = 4.5300000000000002
                        },
                        new
                        {
                            FloorId = 19,
                            FloorColor = "Green",
                            FloorDescription = "Green Wood Floor",
                            FloorName = "Wood",
                            Price = 2.9900000000000002
                        },
                        new
                        {
                            FloorId = 21,
                            FloorColor = "Clear",
                            FloorDescription = "Clear Polycarbonate Floor",
                            FloorName = "Polycarbonate",
                            Price = 0.94999999999999996
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
