using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class branch_office_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddForeignKey(
                name: "FK_RentDetails_BranchOffice_OriginOfficeId",
                table: "RentDetails",
                column: "OriginOfficeId",
                principalTable: "BranchOffice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentDetails_BranchOffice_ReturnOfficeId",
                table: "RentDetails",
                column: "ReturnOfficeId",
                principalTable: "BranchOffice",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentDetails_BranchOffice_OriginOfficeId",
                table: "RentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RentDetails_BranchOffice_ReturnOfficeId",
                table: "RentDetails");

            migrationBuilder.DropTable(
                name: "BranchOffice");

            migrationBuilder.DropIndex(
                name: "IX_RentDetails_OriginOfficeId",
                table: "RentDetails");

            migrationBuilder.DropIndex(
                name: "IX_RentDetails_ReturnOfficeId",
                table: "RentDetails");

            migrationBuilder.DropColumn(
                name: "OriginOfficeId",
                table: "RentDetails");

            migrationBuilder.DropColumn(
                name: "ReturnOfficeId",
                table: "RentDetails");

        }
    }
}
