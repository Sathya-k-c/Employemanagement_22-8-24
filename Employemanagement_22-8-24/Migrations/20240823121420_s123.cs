﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employemanagement_22_8_24.Migrations
{
    /// <inheritdoc />
    public partial class s123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "admin123",
                column: "StartDate",
                value: new DateTime(2024, 8, 23, 17, 44, 20, 93, DateTimeKind.Local).AddTicks(6529));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "admin123",
                column: "StartDate",
                value: new DateTime(2024, 8, 23, 12, 34, 23, 956, DateTimeKind.Local).AddTicks(5419));
        }
    }
}
