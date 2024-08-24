using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employemanagement_22_8_24.Migrations
{
    /// <inheritdoc />
    public partial class q5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "admin123",
                column: "StartDate",
                value: new DateTime(2024, 8, 24, 21, 55, 40, 24, DateTimeKind.Local).AddTicks(5656));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "admin123",
                column: "StartDate",
                value: new DateTime(2024, 8, 24, 21, 53, 2, 513, DateTimeKind.Local).AddTicks(6668));
        }
    }
}
