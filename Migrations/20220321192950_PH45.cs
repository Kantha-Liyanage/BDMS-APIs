using Microsoft.EntityFrameworkCore.Migrations;

namespace BDMS_APIs.Migrations
{
    public partial class PH45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "PasswordHash", table: "Hospitals");
            migrationBuilder.AddColumn<string>(name: "Password", table: "Hospitals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Hospitals",
                newName: "PasswordHash");
        }
    }
}
