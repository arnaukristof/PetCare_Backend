﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetCare.Data;

#nullable disable

namespace PetCare.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241101140522_cleanup made5")]
    partial class cleanupmade5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetCare.Models.Entities.DaysOfWeek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameOfDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DaysOfWeeks");
                });

            modelBuilder.Entity("PetCare.Models.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Indoor")
                        .HasColumnType("bit");

                    b.Property<bool?>("Medication")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PetBreedId")
                        .HasColumnType("int");

                    b.Property<int?>("PetSizeId")
                        .HasColumnType("int");

                    b.Property<int?>("PetTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Verified")
                        .HasColumnType("bit");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetBreedId");

                    b.HasIndex("PetSizeId");

                    b.HasIndex("PetTypeId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("PetCare.Models.Entities.PetBreed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BreedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PetBreeds");
                });

            modelBuilder.Entity("PetCare.Models.Entities.PetSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PetSizes");
                });

            modelBuilder.Entity("PetCare.Models.Entities.PetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PetTypes");
                });

            modelBuilder.Entity("PetCare.Models.Entities.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("PetCare.Models.Entities.Worker_DaysOfWeek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DaysOfWeekId")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DaysOfWeekId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Worker_DaysOfWeeks");
                });

            modelBuilder.Entity("PetCare.Models.Entities.Pet", b =>
                {
                    b.HasOne("PetCare.Models.Entities.PetBreed", "PetBreed")
                        .WithMany("Pets")
                        .HasForeignKey("PetBreedId");

                    b.HasOne("PetCare.Models.Entities.PetSize", "PetSize")
                        .WithMany("Pets")
                        .HasForeignKey("PetSizeId");

                    b.HasOne("PetCare.Models.Entities.PetType", "PetType")
                        .WithMany("Pets")
                        .HasForeignKey("PetTypeId");

                    b.Navigation("PetBreed");

                    b.Navigation("PetSize");

                    b.Navigation("PetType");
                });

            modelBuilder.Entity("PetCare.Models.Entities.Worker_DaysOfWeek", b =>
                {
                    b.HasOne("PetCare.Models.Entities.DaysOfWeek", "DaysOfWeek")
                        .WithMany("Worker_DaysOfWeeks")
                        .HasForeignKey("DaysOfWeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetCare.Models.Entities.Worker", "Worker")
                        .WithMany("Worker_DaysOfWeeks")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaysOfWeek");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("PetCare.Models.Entities.DaysOfWeek", b =>
                {
                    b.Navigation("Worker_DaysOfWeeks");
                });

            modelBuilder.Entity("PetCare.Models.Entities.PetBreed", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PetCare.Models.Entities.PetSize", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PetCare.Models.Entities.PetType", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PetCare.Models.Entities.Worker", b =>
                {
                    b.Navigation("Worker_DaysOfWeeks");
                });
#pragma warning restore 612, 618
        }
    }
}
