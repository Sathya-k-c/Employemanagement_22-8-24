using Microsoft.EntityFrameworkCore;
using Employemanagement_22_8_24.Models;
using Employemanagement_22_8_24.Data.Enums;

namespace Employemanagement_22_8_24.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ForgotPassword> ForgotPasswords { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<UpdatePassword> UpdatePasswords { get; set; }
        public DbSet<ValidateOtp> ValidateOtps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = "admin123",
                Password = "Admin@1234", // Ensure you hash the password
                Role = "Admin",
                IsFirstTimeLogin = false,
                Email = "admin@example.com",
                PersonalPhoneNumber = "1234567890",
                WorkEmail = "admin.work@example.com",
                AccountNumber = "123456789012",
                Name = "Admin User",
                DateOfBirth = new DateTime(1980, 1, 1),
                DateOfJoin = DateTime.Now,
                Gender = Gender.Male,
                MaritalStatus = "Single",
                BloodGroup = Bloodgroup.O_Positive,
                Nationality = "Country",
                ResidentialAddress = "123 Admin St.",
                District = "Admin District",
                State = "Admin State",
                BasicPay = 100000m,
                HRA = 20000m,
                ConveyanceAllowance = 5000m,
                FixedMedicalAllowance = 2000m,
                TotalEarnings = 127000m, // Sum of earnings
                BankName = "Admin Bank",
                AccountHolderName = "Admin User",
                Designation = "Administrator",
                Department = "Management",
                EmploymentType = "Full-Time",
                WorkPhoneNumber = "0987654321",
                LoginCreated =true,
            });

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(100);

                entity.Property(e => e.Role)
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(100);

                entity.Property(e => e.PersonalPhoneNumber)
                    .HasMaxLength(15);

                entity.Property(e => e.WorkEmail)
                    .HasMaxLength(100);

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(12);

                entity.Property(e => e.Name)
                    .HasMaxLength(100);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(50);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50);

                entity.Property(e => e.ResidentialAddress)
                    .HasMaxLength(250);

                entity.Property(e => e.District)
                    .HasMaxLength(100);

                entity.Property(e => e.State)
                    .HasMaxLength(100);

                entity.Property(e => e.BankName)
                    .HasMaxLength(100);

                entity.Property(e => e.AccountHolderName)
                    .HasMaxLength(100);

                entity.Property(e => e.Designation)
                    .HasMaxLength(100);

                entity.Property(e => e.Department)
                    .HasMaxLength(100);

                entity.Property(e => e.EmploymentType)
                    .HasMaxLength(50);

                entity.Property(e => e.WorkPhoneNumber)
                    .HasMaxLength(15);
            });

            // Configure Request entity
            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EditRequest)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RequestDate)
                    .IsRequired();

                entity.Property(e => e.isprocessed)
                    .IsRequired();
            });

            // Configure ForgotPassword entity
            modelBuilder.Entity<ForgotPassword>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Email });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // Configure Login entity
            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // Configure UpdatePassword entity
            modelBuilder.Entity<UpdatePassword>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NewPassword)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // Configure ValidateOtp entity
            modelBuilder.Entity<ValidateOtp>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Otp)
                    .IsRequired()
                    .HasMaxLength(10);
            });

         
        }
    }
}
