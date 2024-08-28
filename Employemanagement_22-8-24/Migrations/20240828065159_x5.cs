using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employemanagement_22_8_24.Migrations
{
    /// <inheritdoc />
    public partial class x5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "admin123",
                column: "DateOfJoin",
                value: new DateTime(2024, 8, 28, 12, 21, 58, 602, DateTimeKind.Local).AddTicks(3119));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "admin123",
                column: "DateOfJoin",
                value: new DateTime(2024, 8, 28, 12, 19, 2, 155, DateTimeKind.Local).AddTicks(9952));
        }
    }
}
