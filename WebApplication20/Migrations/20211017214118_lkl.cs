using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication20.Migrations
{
    public partial class lkl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attendance = table.Column<TimeSpan>(type: "time", nullable: false),
                    Leaving = table.Column<TimeSpan>(type: "time", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeAttendances_Employes_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeAttendances_EmpId",
                table: "EmployeAttendances",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeAttendances");

            migrationBuilder.DropTable(
                name: "Employes");
        }
    }
}
