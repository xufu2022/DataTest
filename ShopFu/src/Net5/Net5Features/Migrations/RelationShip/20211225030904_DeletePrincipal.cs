using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net5Features.Migrations.RelationShip
{
    public partial class DeletePrincipal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeletePrincipal",
                columns: table => new
                {
                    DeletePrincipalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletePrincipal", x => x.DeletePrincipalId);
                });

            migrationBuilder.CreateTable(
                name: "DeleteDependentCascade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletePrincipalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteDependentCascade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeleteDependentCascade_DeletePrincipal_DeletePrincipalId",
                        column: x => x.DeletePrincipalId,
                        principalTable: "DeletePrincipal",
                        principalColumn: "DeletePrincipalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeleteDependentClientCascade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletePrincipalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteDependentClientCascade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeleteDependentClientCascade_DeletePrincipal_DeletePrincipalId",
                        column: x => x.DeletePrincipalId,
                        principalTable: "DeletePrincipal",
                        principalColumn: "DeletePrincipalId");
                });

            migrationBuilder.CreateTable(
                name: "DeleteDependentClientSetNull",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletePrincipalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteDependentClientSetNull", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeleteDependentClientSetNull_DeletePrincipal_DeletePrincipalId",
                        column: x => x.DeletePrincipalId,
                        principalTable: "DeletePrincipal",
                        principalColumn: "DeletePrincipalId");
                });

            migrationBuilder.CreateTable(
                name: "DeleteDependentDefault",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletePrincipalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteDependentDefault", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeleteDependentDefault_DeletePrincipal_DeletePrincipalId",
                        column: x => x.DeletePrincipalId,
                        principalTable: "DeletePrincipal",
                        principalColumn: "DeletePrincipalId");
                });

            migrationBuilder.CreateTable(
                name: "DeleteDependentRestrict",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletePrincipalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteDependentRestrict", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeleteDependentRestrict_DeletePrincipal_DeletePrincipalId",
                        column: x => x.DeletePrincipalId,
                        principalTable: "DeletePrincipal",
                        principalColumn: "DeletePrincipalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeleteDependentSetNull",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletePrincipalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteDependentSetNull", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeleteDependentSetNull_DeletePrincipal_DeletePrincipalId",
                        column: x => x.DeletePrincipalId,
                        principalTable: "DeletePrincipal",
                        principalColumn: "DeletePrincipalId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DeleteNonNullDefault",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletePrincipalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteNonNullDefault", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeleteNonNullDefault_DeletePrincipal_DeletePrincipalId",
                        column: x => x.DeletePrincipalId,
                        principalTable: "DeletePrincipal",
                        principalColumn: "DeletePrincipalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeleteDependentCascade_DeletePrincipalId",
                table: "DeleteDependentCascade",
                column: "DeletePrincipalId",
                unique: true,
                filter: "[DeletePrincipalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeleteDependentClientCascade_DeletePrincipalId",
                table: "DeleteDependentClientCascade",
                column: "DeletePrincipalId",
                unique: true,
                filter: "[DeletePrincipalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeleteDependentClientSetNull_DeletePrincipalId",
                table: "DeleteDependentClientSetNull",
                column: "DeletePrincipalId",
                unique: true,
                filter: "[DeletePrincipalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeleteDependentDefault_DeletePrincipalId",
                table: "DeleteDependentDefault",
                column: "DeletePrincipalId",
                unique: true,
                filter: "[DeletePrincipalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeleteDependentRestrict_DeletePrincipalId",
                table: "DeleteDependentRestrict",
                column: "DeletePrincipalId",
                unique: true,
                filter: "[DeletePrincipalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeleteDependentSetNull_DeletePrincipalId",
                table: "DeleteDependentSetNull",
                column: "DeletePrincipalId",
                unique: true,
                filter: "[DeletePrincipalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeleteNonNullDefault_DeletePrincipalId",
                table: "DeleteNonNullDefault",
                column: "DeletePrincipalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeleteDependentCascade");

            migrationBuilder.DropTable(
                name: "DeleteDependentClientCascade");

            migrationBuilder.DropTable(
                name: "DeleteDependentClientSetNull");

            migrationBuilder.DropTable(
                name: "DeleteDependentDefault");

            migrationBuilder.DropTable(
                name: "DeleteDependentRestrict");

            migrationBuilder.DropTable(
                name: "DeleteDependentSetNull");

            migrationBuilder.DropTable(
                name: "DeleteNonNullDefault");

            migrationBuilder.DropTable(
                name: "DeletePrincipal");
        }
    }
}
