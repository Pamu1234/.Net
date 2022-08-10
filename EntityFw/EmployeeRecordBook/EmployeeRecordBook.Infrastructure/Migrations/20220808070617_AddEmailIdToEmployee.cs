using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRecordBook.Infrastructure.Migrations
{
    public partial class AddEmailIdToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Employees");
        }
    }
}
