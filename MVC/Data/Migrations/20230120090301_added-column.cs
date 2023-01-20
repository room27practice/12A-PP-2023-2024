using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animals.Data.Migrations
{
    public partial class addedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imgUrl",
                table: "FuelCars",
                newName: "ImgUrl");

            migrationBuilder.RenameColumn(
                name: "imgUrl",
                table: "ElectricCars",
                newName: "ImgUrl");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "FuelCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "ElectricCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "FuelCars");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "ElectricCars");

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "FuelCars",
                newName: "imgUrl");

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "ElectricCars",
                newName: "imgUrl");
        }
    }
}
