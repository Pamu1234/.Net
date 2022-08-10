using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentApiPlayground.Infrastructure.Migrations
{
    public partial class AddingDataTostudenteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "EnrollmentDate", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sandwiskj", "Patil" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
