using Microsoft.EntityFrameworkCore.Migrations;

namespace BDMS_APIs.Migrations
{
    public partial class PH11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Hospitals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNo1",
                table: "Hospitals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNo2",
                table: "Hospitals",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "ContactNo1",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "ContactNo2",
                table: "Hospitals");
        }
    }
}
