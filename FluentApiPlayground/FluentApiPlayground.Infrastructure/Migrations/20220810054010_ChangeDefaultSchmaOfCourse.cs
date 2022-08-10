using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentApiPlayground.Infrastructure.Migrations
{
    public partial class ChangeDefaultSchmaOfCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "StudentData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentData",
                table: "StudentData",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_StudentData_CourseID",
                table: "Enrollments",
                column: "CourseID",
                principalTable: "StudentData",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_StudentData_CourseID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentData",
                table: "StudentData");

            migrationBuilder.RenameTable(
                name: "StudentData",
                newName: "Courses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
