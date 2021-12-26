using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net5Features.Migrations.RelationShip
{
    public partial class addmanager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeShortFk",
                columns: table => new
                {
                    EmployeeShortFkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShortFk", x => x.EmployeeShortFkId);
                    table.ForeignKey(
                        name: "FK_EmployeeShortFk_EmployeeShortFk_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "EmployeeShortFk",
                        principalColumn: "EmployeeShortFkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShortFk_ManagerId",
                table: "EmployeeShortFk",
                column: "ManagerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeShortFk");
        }
    }
}
