using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentApiPlayground.Infrastructure.Migrations
{
    public partial class AddingDataToCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "CourseData",
                table: "Course",
                columns: new[] { "CourseID", "Credits", "CourseName" },
                values: new object[] { 111, 3, "C#.Net" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CourseData",
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 111);
        }
    }
}
