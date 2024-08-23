using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employemanagement_22_8_24.Migrations
{
    /// <inheritdoc />
    public partial class todaysecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AccountHolderName", "AccountNumber", "BankName", "BasicPay", "BloodGroup", "ConveyanceAllowance", "DateOfBirth", "Department", "Designation", "District", "Email", "EmploymentType", "FixedMedicalAllowance", "Gender", "HRA", "IsFirstTimeLogin", "MaritalStatus", "Name", "Nationality", "Password", "PersonalPhoneNumber", "ResidentialAddress", "Role", "StartDate", "State", "TotalEarnings", "WorkEmail", "WorkPhoneNumber" },
                values: new object[] { "admin123", "Admin User", "123456789012", "Admin Bank", 100000m, 7, 5000m, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Management", "Administrator", "Admin District", "admin@example.com", "Full-Time", 2000m, 1, 20000m, false, "Single", "Admin User", "Country", "Admin@1234", "1234567890", "123 Admin St.", "Admin", new DateTime(2024, 8, 23, 10, 13, 23, 956, DateTimeKind.Local).AddTicks(458), "Admin State", 127000m, "admin.work@example.com", "0987654321" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "admin123");
        }
    }
}
