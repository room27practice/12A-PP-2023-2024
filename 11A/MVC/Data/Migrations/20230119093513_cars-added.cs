using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animals.Data.Migrations
{
    public partial class carsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batteries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxCapacity = table.Column<double>(type: "float", nullable: false),
                    RemainingCapacity = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeCycles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batteries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxCapacity = table.Column<double>(type: "float", nullable: false),
                    RemainingCapacity = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BateryId = table.Column<int>(type: "int", nullable: false),
                    TravelDistanceKoef = table.Column<double>(type: "float", nullable: false),
                    MaxTravelDistance = table.Column<double>(type: "float", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYearOfModel = table.Column<int>(type: "int", nullable: false),
                    MaxSpeedKmPh = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    LoadCappacity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricCars_Batteries_BateryId",
                        column: x => x.BateryId,
                        principalTable: "Batteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuelCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelDistanceKoef = table.Column<double>(type: "float", nullable: false),
                    MaxTravelDistance = table.Column<double>(type: "float", nullable: false),
                    TankId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYearOfModel = table.Column<int>(type: "int", nullable: false),
                    MaxSpeedKmPh = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    LoadCappacity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelCars_Tanks_TankId",
                        column: x => x.TankId,
                        principalTable: "Tanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectricCars_BateryId",
                table: "ElectricCars",
                column: "BateryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuelCars_TankId",
                table: "FuelCars",
                column: "TankId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricCars");

            migrationBuilder.DropTable(
                name: "FuelCars");

            migrationBuilder.DropTable(
                name: "Batteries");

            migrationBuilder.DropTable(
                name: "Tanks");
        }
    }
}
