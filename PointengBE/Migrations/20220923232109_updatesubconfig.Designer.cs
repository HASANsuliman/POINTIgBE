﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PointengBE.Models.Context;

#nullable disable

namespace PointengBE.Migrations
{
    [DbContext(typeof(PointingContext))]
    [Migration("20220923232109_updatesubconfig")]
    partial class updatesubconfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PointengBE.Models.Auth.CustomClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomClaims");
                });

            modelBuilder.Entity("PointengBE.Models.Context.LogHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Month")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogHistories");
                });

            modelBuilder.Entity("PointengBE.Models.DirectConfig", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateEntry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Month")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("RangeFrom")
                        .HasColumnType("int");

                    b.Property<int>("RangeTo")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("DirectConfigs");
                });

            modelBuilder.Entity("PointengBE.Models.Locations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AREA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CITY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REGION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SUBAREA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalesRep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sd_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shop_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supervisor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZONE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("PointengBE.Models.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DateEntry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateUpdated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinValue")
                        .HasColumnType("int");

                    b.Property<DateTime>("Month")
                        .HasColumnType("datetime2");

                    b.Property<int>("PointPrice")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserUpdate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("PointengBE.Models.SubDirectConfigs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AREA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CITY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateEntry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExtraPoints")
                        .HasColumnType("int");

                    b.Property<DateTime>("Month")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("REGION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RangeFrom")
                        .HasColumnType("int");

                    b.Property<Guid>("RangeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RangeTo")
                        .HasColumnType("int");

                    b.Property<string>("SUBAREA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SUBDEALER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubConfigId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZONE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubDirectConfigs");
                });

            modelBuilder.Entity("PointengBE.Models.DirectConfig", b =>
                {
                    b.HasOne("PointengBE.Models.Plan", "Plan")
                        .WithMany("DirectConfigs")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("PointengBE.Models.Plan", b =>
                {
                    b.Navigation("DirectConfigs");
                });
#pragma warning restore 612, 618
        }
    }
}
