﻿// <auto-generated />
using System;
using AspTravelerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspTravelerApp.Migrations
{
    [DbContext(typeof(TripDbContext))]
    [Migration("20190320193807_Adding Segments")]
    partial class AddingSegments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085");

            modelBuilder.Entity("AspTravelerApp.Models.Segment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArrivalAddress");

                    b.Property<string>("DepartureAddress");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ReservationID");

                    b.Property<string>("ReservationLocation");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("TripId");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("TripId");

                    b.ToTable("Segments");
                });

            modelBuilder.Entity("AspTravelerApp.Models.Trip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("AspTravelerApp.Models.Segment", b =>
                {
                    b.HasOne("AspTravelerApp.Models.Trip", "TripID")
                        .WithMany("Segments")
                        .HasForeignKey("TripId");
                });
#pragma warning restore 612, 618
        }
    }
}
