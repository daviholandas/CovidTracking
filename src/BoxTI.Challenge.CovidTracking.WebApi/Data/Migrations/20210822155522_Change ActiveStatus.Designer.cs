﻿// <auto-generated />
using System;
using BoxTI.Challenge.CovidTracking.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoxTI.Challenge.CovidTracking.WebApi.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210822155522_Change ActiveStatus")]
    partial class ChangeActiveStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoxTI.Challenge.CovidTracking.WebApi.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("varchar(125)");

                    b.Property<int>("ActiveStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(125)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5f6ccc7-f4ca-4464-a19d-e34f91c449ba"),
                            Abbreviation = "BR",
                            ActiveStatus = 1,
                            Name = "Brazil"
                        },
                        new
                        {
                            Id = new Guid("67a45522-526a-465f-b561-dc324cfebc3d"),
                            Abbreviation = "JP",
                            ActiveStatus = 1,
                            Name = "Japan"
                        },
                        new
                        {
                            Id = new Guid("dab860dc-cfe8-4aea-835a-9cc598c357fd"),
                            Abbreviation = "NL",
                            ActiveStatus = 1,
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = new Guid("4ad0e2a6-6ddb-4cd1-badc-ca7e4882d59d"),
                            Abbreviation = "NG",
                            ActiveStatus = 1,
                            Name = "Nigeria"
                        },
                        new
                        {
                            Id = new Guid("47db3c74-ddf8-46c1-ab01-a1400b47cf5f"),
                            Abbreviation = "AU",
                            ActiveStatus = 1,
                            Name = "Australia"
                        },
                        new
                        {
                            Id = new Guid("43cd6707-0e21-41cd-b345-489799f51205"),
                            Abbreviation = "W",
                            ActiveStatus = 1,
                            Name = "World"
                        });
                });

            modelBuilder.Entity("BoxTI.Challenge.CovidTracking.WebApi.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActiveCases")
                        .HasColumnType("varchar(125)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NewCases")
                        .HasColumnType("varchar(125)");

                    b.Property<string>("NewDeaths")
                        .HasColumnType("varchar(125)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalCases")
                        .HasColumnType("float");

                    b.Property<double>("TotalDeaths")
                        .HasColumnType("float");

                    b.Property<double>("TotalRecovered")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("BoxTI.Challenge.CovidTracking.WebApi.Models.Report", b =>
                {
                    b.HasOne("BoxTI.Challenge.CovidTracking.WebApi.Models.Location", "Location")
                        .WithMany("Reports")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("BoxTI.Challenge.CovidTracking.WebApi.Models.Location", b =>
                {
                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
