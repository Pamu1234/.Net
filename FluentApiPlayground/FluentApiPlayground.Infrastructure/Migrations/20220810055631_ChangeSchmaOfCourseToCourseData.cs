using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentApiPlayground.Infrastructure.Migrations
{
    public partial class ChangeSchmaOfCourseToCourseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Course",
                newSchema: "CourseData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                schema: "CourseData",
                table: "Course",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Course_CourseID",
                table: "Enrollments",
                column: "CourseID",
                principalSchema: "CourseData",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Course_CourseID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                schema: "CourseData",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Course",
                schema: "CourseData",
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
    }
}
