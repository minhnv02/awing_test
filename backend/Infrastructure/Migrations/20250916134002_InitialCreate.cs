using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreasureMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rows = table.Column<int>(type: "int", nullable: false),
                    Cols = table.Column<int>(type: "int", nullable: false),
                    P = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasureMaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapCells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Col = table.Column<int>(type: "int", nullable: false),
                    ChestNumber = table.Column<int>(type: "int", nullable: false),
                    TreasureMapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapCells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapCells_TreasureMaps_TreasureMapId",
                        column: x => x.TreasureMapId,
                        principalTable: "TreasureMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapCells_TreasureMapId",
                table: "MapCells",
                column: "TreasureMapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapCells");

            migrationBuilder.DropTable(
                name: "TreasureMaps");
        }
    }
}
