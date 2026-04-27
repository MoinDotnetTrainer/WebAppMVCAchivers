using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class citizen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citizen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    refid = table.Column<int>(type: "int", nullable: false),
                    CitizenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Voters_Citizen_CitizenID",
                        column: x => x.CitizenID,
                        principalTable: "Citizen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voters_CitizenID",
                table: "Voters",
                column: "CitizenID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voters");

            migrationBuilder.DropTable(
                name: "Citizen");
        }
    }
}
