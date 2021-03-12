﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PregnancyDemoApp.AppDbContext;

namespace PregnancyDemoApp.Migrations
{
    [DbContext(typeof(PregnancyDbContext))]
    [Migration("20210312220934_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PregnancyDemoApp.Models.Childbirth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Childbirths");
                });

            modelBuilder.Entity("PregnancyDemoApp.Models.Obstetrician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Obstetricians");
                });

            modelBuilder.Entity("PregnancyDemoApp.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NatIdNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NatIdNr")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PregnancyDemoApp.Models.Pregnancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChildbirthId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MotherId")
                        .HasColumnType("int");

                    b.Property<int>("ObstetricianId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChildbirthId")
                        .IsUnique();

                    b.HasIndex("ObstetricianId");

                    b.HasIndex("PersonId");

                    b.ToTable("Pregnancies");
                });

            modelBuilder.Entity("PregnancyDemoApp.Models.Obstetrician", b =>
                {
                    b.HasOne("PregnancyDemoApp.Models.Person", "Person")
                        .WithOne("Obstetrician")
                        .HasForeignKey("PregnancyDemoApp.Models.Obstetrician", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PregnancyDemoApp.Models.Pregnancy", b =>
                {
                    b.HasOne("PregnancyDemoApp.Models.Childbirth", "Childbirth")
                        .WithOne("Pregnancy")
                        .HasForeignKey("PregnancyDemoApp.Models.Pregnancy", "ChildbirthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PregnancyDemoApp.Models.Obstetrician", "Obstetrician")
                        .WithMany("Pregnancies")
                        .HasForeignKey("ObstetricianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PregnancyDemoApp.Models.Person", "Person")
                        .WithMany("Pregnancies")
                        .HasForeignKey("PersonId");

                    b.Navigation("Childbirth");

                    b.Navigation("Obstetrician");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PregnancyDemoApp.Models.Childbirth", b =>
                {
                    b.Navigation("Pregnancy");
                });

            modelBuilder.Entity("PregnancyDemoApp.Models.Obstetrician", b =>
                {
                    b.Navigation("Pregnancies");
                });

            modelBuilder.Entity("PregnancyDemoApp.Models.Person", b =>
                {
                    b.Navigation("Obstetrician");

                    b.Navigation("Pregnancies");
                });
#pragma warning restore 612, 618
        }
    }
}
