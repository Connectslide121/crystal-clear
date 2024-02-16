﻿// <auto-generated />
using System;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseConnection.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240216164011_remove-cities-from-option")]
    partial class removecitiesfromoption
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PricePerSquareMeter")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Core.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("OptionId");

                    b.HasIndex("CityId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Core.Option", b =>
                {
                    b.HasOne("Core.City", null)
                        .WithMany("AvailableOptions")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("Core.City", b =>
                {
                    b.Navigation("AvailableOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
