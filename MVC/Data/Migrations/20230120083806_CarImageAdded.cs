using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animals.Data.Migrations
{
    public partial class CarImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "FuelCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "ElectricCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "FuelCars");

            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "ElectricCars");
        }
    }
}
