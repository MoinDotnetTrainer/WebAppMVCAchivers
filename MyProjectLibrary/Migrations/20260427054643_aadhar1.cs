using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class aadhar1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Aadhar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Aadhar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PanUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pan_Tbl_Aadhar_AadharID",
                        column: x => x.AadharID,
                        principalTable: "Tbl_Aadhar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pan_AadharID",
                table: "Pan",
                column: "AadharID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pan");

            migrationBuilder.DropTable(
                name: "Tbl_Aadhar");
        }
    }
}
