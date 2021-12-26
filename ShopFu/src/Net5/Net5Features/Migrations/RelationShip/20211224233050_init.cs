using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net5Features.Migrations.RelationShip
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OptionalTrack",
                columns: table => new
                {
                    OptionalTrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Track = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalTrack", x => x.OptionalTrackId);
                });

            migrationBuilder.CreateTable(
                name: "RequiredTrack",
                columns: table => new
                {
                    RequiredTrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Track = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredTrack", x => x.RequiredTrackId);
                });

            migrationBuilder.CreateTable(
                name: "TicketOption1",
                columns: table => new
                {
                    TicketOption1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketOption1", x => x.TicketOption1Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    AttendeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionalTrackId = table.Column<int>(type: "int", nullable: false),
                    MyShadowFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.AttendeeId);
                    table.ForeignKey(
                        name: "FK_Attendee_OptionalTrack_OptionalTrackId",
                        column: x => x.OptionalTrackId,
                        principalTable: "OptionalTrack",
                        principalColumn: "OptionalTrackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendee_RequiredTrack_MyShadowFk",
                        column: x => x.MyShadowFk,
                        principalTable: "RequiredTrack",
                        principalColumn: "RequiredTrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShadowAttendee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShadowAttendee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShadowAttendee_TicketOption1_Id",
                        column: x => x.Id,
                        principalTable: "TicketOption1",
                        principalColumn: "TicketOption1Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShadowAttendeeNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShadowAttendeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShadowAttendeeNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShadowAttendeeNote_ShadowAttendee_ShadowAttendeeId",
                        column: x => x.ShadowAttendeeId,
                        principalTable: "ShadowAttendee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketOption2",
                columns: table => new
                {
                    TicketOption2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketOption2", x => x.TicketOption2Id);
                    table.ForeignKey(
                        name: "FK_TicketOption2_ShadowAttendee_TicketOption2Id",
                        column: x => x.TicketOption2Id,
                        principalTable: "ShadowAttendee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_MyShadowFk",
                table: "Attendee",
                column: "MyShadowFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_OptionalTrackId",
                table: "Attendee",
                column: "OptionalTrackId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShadowAttendeeNote_ShadowAttendeeId",
                table: "ShadowAttendeeNote",
                column: "ShadowAttendeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "ShadowAttendeeNote");

            migrationBuilder.DropTable(
                name: "TicketOption2");

            migrationBuilder.DropTable(
                name: "OptionalTrack");

            migrationBuilder.DropTable(
                name: "RequiredTrack");

            migrationBuilder.DropTable(
                name: "ShadowAttendee");

            migrationBuilder.DropTable(
                name: "TicketOption1");
        }
    }
}
