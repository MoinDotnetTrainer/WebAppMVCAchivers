using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class citizen1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voters_Citizen_CitizenID",
                table: "Voters");

            migrationBuilder.DropIndex(
                name: "IX_Voters_CitizenID",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "CitizenID",
                table: "Voters");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_refid",
                table: "Voters",
                column: "refid");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_Citizen_refid",
                table: "Voters",
                column: "refid",
                principalTable: "Citizen",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voters_Citizen_refid",
                table: "Voters");

            migrationBuilder.DropIndex(
                name: "IX_Voters_refid",
                table: "Voters");

            migrationBuilder.AddColumn<int>(
                name: "CitizenID",
                table: "Voters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Voters_CitizenID",
                table: "Voters",
                column: "CitizenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_Citizen_CitizenID",
                table: "Voters",
                column: "CitizenID",
                principalTable: "Citizen",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
