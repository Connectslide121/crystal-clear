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
    [Migration("20240216233912_rename-ids")]
    partial class renameids
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CityOption", b =>
                {
                    b.Property<int>("AvailableOptionsId")
                        .HasColumnType("int");

                    b.Property<int>("CitiesId")
                        .HasColumnType("int");

                    b.HasKey("AvailableOptionsId", "CitiesId");

                    b.HasIndex("CitiesId");

                    b.ToTable("CityOption");
                });

            modelBuilder.Entity("Core.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PricePerSquareMeter")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Core.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("QuoteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuoteId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Core.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CretedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("CityOption", b =>
                {
                    b.HasOne("Core.Option", null)
                        .WithMany()
                        .HasForeignKey("AvailableOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.City", null)
                        .WithMany()
                        .HasForeignKey("CitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Option", b =>
                {
                    b.HasOne("Core.Quote", null)
                        .WithMany("SelectedOptions")
                        .HasForeignKey("QuoteId");
                });

            modelBuilder.Entity("Core.Quote", b =>
                {
                    b.HasOne("Core.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Core.Quote", b =>
                {
                    b.Navigation("SelectedOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
