using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeWebApplication.Migrations
{
    public partial class LinkEmployeeToIdentityUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ownerID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "permission",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "ownerID",
                table: "Employee",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "permission",
                table: "Employee",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
