using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentApiPlayground.Infrastructure.Migrations
{
    public partial class ChangeDefaultSchmaOfCourseToCourseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_StudentData_CourseID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentData",
                table: "StudentData");

            migrationBuilder.EnsureSchema(
                name: "CourseData");

            migrationBuilder.RenameTable(
                name: "StudentData",
                newName: "Courses",
                newSchema: "CourseData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                schema: "CourseData",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments",
                column: "CourseID",
                principalSchema: "CourseData",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                schema: "CourseData",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "CourseData",
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
    }
}
