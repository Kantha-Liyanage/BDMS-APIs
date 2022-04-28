﻿// <auto-generated />
using System;
using BDMS_APIs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BDMS_APIs.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("BDMS_APIs.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CampaignID")
                        .HasColumnType("text");

                    b.Property<string>("DonorNIC")
                        .HasColumnType("text");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int>("TimeSlot")
                        .HasColumnType("int");

                    b.HasKey("AppointmentID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("BDMS_APIs.Models.DonationCampaign", b =>
                {
                    b.Property<string>("CampaignID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("BloodGroups")
                        .HasColumnType("text");

                    b.Property<DateTime>("CampaignDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CampaignName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("HospitalID")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int>("TimeSlots")
                        .HasColumnType("int");

                    b.HasKey("CampaignID");

                    b.ToTable("DonationCampaign");
                });

            modelBuilder.Entity("BDMS_APIs.Models.Donor", b =>
                {
                    b.Property<string>("NIC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("BloodGroup")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("NIC");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("BDMS_APIs.Models.Hospital", b =>
                {
                    b.Property<string>("HospitalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("ContactNo1")
                        .HasColumnType("text");

                    b.Property<string>("ContactNo2")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("HospitalID");

                    b.ToTable("Hospitals");
                });
#pragma warning restore 612, 618
        }
    }
}
