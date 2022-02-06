using Microsoft.EntityFrameworkCore.Migrations;

namespace VMDataAccess.Migrations
{
    public partial class BrandModelVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Brands_BrandId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Vehicles",
                newName: "ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_BrandId",
                table: "Vehicles",
                newName: "IX_Vehicles_ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "Vehicles",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                newName: "IX_Vehicles_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Brands_BrandId",
                table: "Vehicles",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
