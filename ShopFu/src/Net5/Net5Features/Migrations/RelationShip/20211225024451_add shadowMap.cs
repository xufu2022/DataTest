using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net5Features.Migrations.RelationShip
{
    public partial class addshadowMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.UniqueConstraint("AK_Person_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    ContactInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandlineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.ContactInfoId);
                    table.ForeignKey(
                        name: "FK_ContactInfo_Person_EmailAddress",
                        column: x => x.EmailAddress,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryBook",
                columns: table => new
                {
                    LibraryBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibrarianUserId = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    LibrarianPersonId = table.Column<int>(type: "int", nullable: false),
                    OnLoanToPersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBook", x => x.LibraryBookId);
                    table.ForeignKey(
                        name: "FK_LibraryBook_Person_LibrarianPersonId",
                        column: x => x.LibrarianPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryBook_Person_OnLoanToPersonId",
                        column: x => x.OnLoanToPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_EmailAddress",
                table: "ContactInfo",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBook_LibrarianPersonId",
                table: "LibraryBook",
                column: "LibrarianPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBook_OnLoanToPersonId",
                table: "LibraryBook",
                column: "OnLoanToPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.DropTable(
                name: "LibraryBook");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
