using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class rename_branch_offices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentDetails_BranchOffice_OriginOfficeId",
                table: "RentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RentDetails_BranchOffice_ReturnOfficeId",
                table: "RentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchOffice",
                table: "BranchOffice");

            migrationBuilder.RenameTable(
                name: "BranchOffice",
                newName: "BranchOffices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchOffices",
                table: "BranchOffices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentDetails_BranchOffices_OriginOfficeId",
                table: "RentDetails",
                column: "OriginOfficeId",
                principalTable: "BranchOffices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentDetails_BranchOffices_ReturnOfficeId",
                table: "RentDetails",
                column: "ReturnOfficeId",
                principalTable: "BranchOffices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentDetails_BranchOffices_OriginOfficeId",
                table: "RentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RentDetails_BranchOffices_ReturnOfficeId",
                table: "RentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchOffices",
                table: "BranchOffices");

            migrationBuilder.RenameTable(
                name: "BranchOffices",
                newName: "BranchOffice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchOffice",
                table: "BranchOffice",
                column: "Id");

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
    }
}
