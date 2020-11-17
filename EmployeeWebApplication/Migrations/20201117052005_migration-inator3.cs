using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeWebApplication.Migrations
{
    public partial class migrationinator3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEmergencyContact_AspNetUsers_IdNavigationId",
                table: "EmployeeEmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeExpenses_AspNetUsers_IdNavigationId",
                table: "EmployeeExpenses");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeExpenses_IdNavigationId",
                table: "EmployeeExpenses");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeEmergencyContact_IdNavigationId",
                table: "EmployeeEmergencyContact");

            migrationBuilder.DropColumn(
                name: "IdNavigationId",
                table: "EmployeeExpenses");

            migrationBuilder.DropColumn(
                name: "IdNavigationId",
                table: "EmployeeEmergencyContact");

            migrationBuilder.DropColumn(
                name: "phone_type",
                table: "EmployeeEmergencyContact");

            migrationBuilder.DropColumn(
                name: "relationship_to_employee",
                table: "EmployeeEmergencyContact");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeExpenses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeEmergencyContact",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneType",
                table: "EmployeeEmergencyContact",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RelationshipToEmployee",
                table: "EmployeeEmergencyContact",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExpenses_EmployeeId",
                table: "EmployeeExpenses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmergencyContact_EmployeeId",
                table: "EmployeeEmergencyContact",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEmergencyContact_AspNetUsers_EmployeeId",
                table: "EmployeeEmergencyContact",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeExpenses_AspNetUsers_EmployeeId",
                table: "EmployeeExpenses",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEmergencyContact_AspNetUsers_EmployeeId",
                table: "EmployeeEmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeExpenses_AspNetUsers_EmployeeId",
                table: "EmployeeExpenses");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeExpenses_EmployeeId",
                table: "EmployeeExpenses");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeEmergencyContact_EmployeeId",
                table: "EmployeeEmergencyContact");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeExpenses");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeEmergencyContact");

            migrationBuilder.DropColumn(
                name: "PhoneType",
                table: "EmployeeEmergencyContact");

            migrationBuilder.DropColumn(
                name: "RelationshipToEmployee",
                table: "EmployeeEmergencyContact");

            migrationBuilder.AddColumn<string>(
                name: "IdNavigationId",
                table: "EmployeeExpenses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdNavigationId",
                table: "EmployeeEmergencyContact",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "phone_type",
                table: "EmployeeEmergencyContact",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "relationship_to_employee",
                table: "EmployeeEmergencyContact",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExpenses_IdNavigationId",
                table: "EmployeeExpenses",
                column: "IdNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmergencyContact_IdNavigationId",
                table: "EmployeeEmergencyContact",
                column: "IdNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEmergencyContact_AspNetUsers_IdNavigationId",
                table: "EmployeeEmergencyContact",
                column: "IdNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeExpenses_AspNetUsers_IdNavigationId",
                table: "EmployeeExpenses",
                column: "IdNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
