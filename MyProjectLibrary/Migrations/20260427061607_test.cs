using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pan_AadharID",
                table: "Pan");

            migrationBuilder.CreateIndex(
                name: "IX_Pan_AadharID",
                table: "Pan",
                column: "AadharID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pan_AadharID",
                table: "Pan");

            migrationBuilder.CreateIndex(
                name: "IX_Pan_AadharID",
                table: "Pan",
                column: "AadharID");
        }
    }
}
