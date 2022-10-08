using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Batch17_WebApp.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Salaray",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayrunDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Salaray", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Salaray_tbl_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "tbl_Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Employee_Email",
                table: "tbl_Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Salaray_EmployeeID",
                table: "Tbl_Salaray",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Salaray");

            migrationBuilder.DropTable(
                name: "tbl_Employee");
        }
    }
}
