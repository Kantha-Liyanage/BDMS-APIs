using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDMS_APIs.Migrations
{
    public partial class M20220420_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Donors");

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
                    DateAndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeSlots = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationCampaign", x => x.CampaignID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationCampaign");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Hospitals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Donors",
                type: "text",
                nullable: true);
        }
    }
}
