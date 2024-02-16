﻿// <auto-generated />
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseConnection.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240216164358_add-cities-to-option")]
    partial class addcitiestooption
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
                    b.Property<int>("AvailableOptionsOptionId")
                        .HasColumnType("int");

                    b.Property<int>("CitiesCityId")
                        .HasColumnType("int");

                    b.HasKey("AvailableOptionsOptionId", "CitiesCityId");

                    b.HasIndex("CitiesCityId");

                    b.ToTable("CityOption");
                });

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("OptionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("CityOption", b =>
                {
                    b.HasOne("Core.Option", null)
                        .WithMany()
                        .HasForeignKey("AvailableOptionsOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.City", null)
                        .WithMany()
                        .HasForeignKey("CitiesCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
