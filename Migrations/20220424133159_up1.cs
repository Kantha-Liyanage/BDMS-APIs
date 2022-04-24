using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace BDMS_APIs.Migrations
{
    public partial class up1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CampaignID = table.Column<string>(type: "text", nullable: true),
                    DonorNIC = table.Column<string>(type: "text", nullable: true),
                    TimeSlot = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                });

            migrationBuilder.CreateTable(
                name: "DonationCampaign",
                columns: table => new
                {
                    CampaignID = table.Column<string>(type: "varchar(767)", nullable: false),
                    HospitalID = table.Column<string>(type: "text", nullable: true),
                    CampaignName = table.Column<string>(type: "text", nullable: true),
                    BloodGroups = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    CampaignDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    TimeSlots = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationCampaign", x => x.CampaignID);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    NIC = table.Column<string>(type: "varchar(767)", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false),
                    BloodGroup = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.NIC);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalID = table.Column<string>(type: "varchar(767)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    ContactNo1 = table.Column<string>(type: "text", nullable: true),
                    ContactNo2 = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "DonationCampaign");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
