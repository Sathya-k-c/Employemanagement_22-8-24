﻿// <auto-generated />
using System;
using Employemanagement_22_8_24.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employemanagement_22_8_24.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240824161216_q2")]
    partial class q2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Employemanagement_22_8_24.Models.ForgotPassword", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId", "Email");

                    b.ToTable("ForgotPasswords");
                });

            modelBuilder.Entity("Employemanagement_22_8_24.Models.Login", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Employemanagement_22_8_24.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<string>("EditRequest")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("isprocessed")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Employemanagement_22_8_24.Models.UpdatePassword", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NewPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("UpdatePasswords");
                });

            modelBuilder.Entity("Employemanagement_22_8_24.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AccountHolderName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("BasicPay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BloodGroup")
                        .HasColumnType("int");

                    b.Property<decimal>("ConveyanceAllowance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmploymentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("FixedMedicalAllowance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<decimal>("HRA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsFirstTimeLogin")
                        .HasColumnType("bit");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PersonalPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ResidentialAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("TotalEarnings")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WorkEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WorkPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = "admin123",
                            AccountHolderName = "Admin User",
                            AccountNumber = "123456789012",
                            BankName = "Admin Bank",
                            BasicPay = 100000m,
                            BloodGroup = 7,
                            ConveyanceAllowance = 5000m,
                            DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department = "Management",
                            Designation = "Administrator",
                            District = "Admin District",
                            Email = "admin@example.com",
                            EmploymentType = "Full-Time",
                            FixedMedicalAllowance = 2000m,
                            Gender = 1,
                            HRA = 20000m,
                            IsFirstTimeLogin = false,
                            MaritalStatus = "Single",
                            Name = "Admin User",
                            Nationality = "Country",
                            Password = "Admin@1234",
                            PersonalPhoneNumber = "1234567890",
                            ResidentialAddress = "123 Admin St.",
                            Role = "Admin",
                            StartDate = new DateTime(2024, 8, 24, 21, 42, 16, 38, DateTimeKind.Local).AddTicks(4349),
                            State = "Admin State",
                            TotalEarnings = 127000m,
                            WorkEmail = "admin.work@example.com",
                            WorkPhoneNumber = "0987654321"
                        });
                });

            modelBuilder.Entity("Employemanagement_22_8_24.Models.ValidateOtp", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Otp")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UserId");

                    b.ToTable("ValidateOtps");
                });
#pragma warning restore 612, 618
        }
    }
}
