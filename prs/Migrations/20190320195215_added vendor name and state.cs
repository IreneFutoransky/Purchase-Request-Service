using Microsoft.EntityFrameworkCore.Migrations;

namespace prsserver.Migrations
{
    public partial class addedvendornameandstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vendors",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Vendors",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Vendors");
        }
    }
}
