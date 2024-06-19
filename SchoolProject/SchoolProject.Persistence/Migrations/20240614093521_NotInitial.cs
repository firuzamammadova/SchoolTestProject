using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NotInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<string>(type: "char(3)", fixedLength: true, maxLength: 3, nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "Date", "LessonId", "Mark", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "M1", 99, 1 },
                    { 2, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "M1", 95, 2 },
                    { 3, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "G1", 91, 2 },
                    { 4, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "G1", 100, 1 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Class", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 1, "Meredith", "Grey" },
                    { 2, 1, "Christina", "Yang" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
