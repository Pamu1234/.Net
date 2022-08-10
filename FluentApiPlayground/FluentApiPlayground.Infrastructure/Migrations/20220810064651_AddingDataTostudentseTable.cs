using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentApiPlayground.Infrastructure.Migrations
{
    public partial class AddingDataTostudentseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "EnrollmentDate", "FirstName", "LastName" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fjhgsjdn", "Pande" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
