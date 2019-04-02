using Microsoft.EntityFrameworkCore.Migrations;

namespace prsserver.Migrations
{
    public partial class updatedrequestrequestlineandvendorcontrols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestsLine_Products_ProductId",
                table: "RequestsLine");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestsLine_Requests_RequestId",
                table: "RequestsLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestsLine",
                table: "RequestsLine");

            migrationBuilder.RenameTable(
                name: "RequestsLine",
                newName: "RequestLines");

            migrationBuilder.RenameIndex(
                name: "IX_RequestsLine_RequestId",
                table: "RequestLines",
                newName: "IX_RequestLines_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestsLine_ProductId",
                table: "RequestLines",
                newName: "IX_RequestLines_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestLines",
                table: "RequestLines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestLines_Products_ProductId",
                table: "RequestLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestLines_Requests_RequestId",
                table: "RequestLines",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestLines_Products_ProductId",
                table: "RequestLines");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestLines_Requests_RequestId",
                table: "RequestLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestLines",
                table: "RequestLines");

            migrationBuilder.RenameTable(
                name: "RequestLines",
                newName: "RequestsLine");

            migrationBuilder.RenameIndex(
                name: "IX_RequestLines_RequestId",
                table: "RequestsLine",
                newName: "IX_RequestsLine_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestLines_ProductId",
                table: "RequestsLine",
                newName: "IX_RequestsLine_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestsLine",
                table: "RequestsLine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsLine_Products_ProductId",
                table: "RequestsLine",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsLine_Requests_RequestId",
                table: "RequestsLine",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
