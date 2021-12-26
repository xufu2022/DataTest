using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net5Features.Migrations.RelationShip
{
    public partial class container : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlasticContainer",
                columns: table => new
                {
                    ContainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacityMl = table.Column<int>(type: "int", nullable: false),
                    Shape = table.Column<int>(type: "int", nullable: false),
                    ColorARGB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeightMm = table.Column<int>(type: "int", nullable: false),
                    WidthMm = table.Column<int>(type: "int", nullable: false),
                    DepthMm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlasticContainer", x => x.ContainerId);
                });

            migrationBuilder.CreateTable(
                name: "ShippingContainer",
                columns: table => new
                {
                    ContainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThicknessMm = table.Column<int>(type: "int", nullable: false),
                    DoorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackingMax = table.Column<int>(type: "int", nullable: false),
                    Refrigerated = table.Column<bool>(type: "bit", nullable: false),
                    HeightMm = table.Column<int>(type: "int", nullable: false),
                    WidthMm = table.Column<int>(type: "int", nullable: false),
                    DepthMm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingContainer", x => x.ContainerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlasticContainer");

            migrationBuilder.DropTable(
                name: "ShippingContainer");
        }
    }
}
