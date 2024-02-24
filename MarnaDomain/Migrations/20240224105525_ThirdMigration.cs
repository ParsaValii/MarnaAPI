using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarnaDomain.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OverTime_Employees_EmployeeId",
                table: "OverTime");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "OverTime",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OverTime_Employees_EmployeeId",
                table: "OverTime",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OverTime_Employees_EmployeeId",
                table: "OverTime");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "OverTime",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_OverTime_Employees_EmployeeId",
                table: "OverTime",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
