using Employemanagement_22_8_24.Data.Enums;
using Employemanagement_22_8_24.Data.Services;
using Employemanagement_22_8_24.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Employemanagement_22_8_24.Controllers
{
    
    public class AdminController : Controller
    {
        
        private readonly IADMINSERVICE _adminService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IADMINSERVICE adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Admindashboard()
        {
            return View();
        }
        //--------------------------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            string newUserId = await _adminService.GenerateUserIdAsync();
            var model = new User
            {
                UserId = newUserId
            };
            return View(model);
        }
        [HttpGet]
        
        public JsonResult GetUserIdSuggestions(string term)
        {
            var suggestions = _adminService.GetUserIdSuggestions(term);
            return Json(suggestions);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User model)
        {
            if (true)
            {
                await _adminService.CreateUserAsync(model);
                return RedirectToAction("AdminDashboard");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLogin(string userId, string email)
        {
            var existingUser = await _adminService.GetUserByIdAsync(userId);

            if (existingUser == null)
            {
                ModelState.AddModelError("UserId", "User not found.");
            }
            else if (existingUser.LoginCreated)
            {
                ModelState.AddModelError("UserId", "Login already created for this user.");
            }
            else
            {
                try
                {
                    await _adminService.AddLoginAsync(userId, email);
                    return RedirectToAction("AdminDashboard");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating login");
                    ModelState.AddModelError("", "An error occurred while creating login.");
                }
            }

            return View();
        }




        //---------------------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult> AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User model)
        {
            if (true)
            {
                await _adminService.AddUserAsync(model);
                return RedirectToAction("ViewUsers");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ViewUserDetails(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return NotFound(); // Handle the case where userId is not provided
            }

            var userDetails = await _adminService.GetUserByIdAsync(userId);

            if (userDetails == null)
            {
                return NotFound(); // Handle the case where the user is not found
            }

            return View(userDetails); // Return the user details view
        }

        [HttpGet]
        public async Task<ActionResult> ViewUsers()
        {
            var users = await _adminService.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<ActionResult> EditUser(string userId)
        {
            var userDetails = await _adminService.GetUserByIdAsync(userId);
            return View(userDetails);
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(User model)
        {
            if (true)
            {
                await _adminService.UpdateUserDetailsAsync(model);
                return RedirectToAction("ViewUsers");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(string Id)
        {
            var userDetails = await _adminService.GetUserByIdAsync(Id);
            await _adminService.DeleteUserAsync(userDetails);
            return RedirectToAction("ViewUsers");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        //----------------------------------------------------------------------------------------------------------------------

        // POST: Admin/DownloadUsers
        [HttpPost]
        public async Task<IActionResult> DownloadUsers()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var users = await _adminService.GetAllUsersAsync();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Users");

                // Add header row
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Email";
                worksheet.Cells[1, 3].Value = "Name";
                worksheet.Cells[1, 4].Value = "DOB";
                worksheet.Cells[1, 5].Value = "Basic Pay";
                worksheet.Cells[1, 6].Value = "Total Earnings";
                worksheet.Cells[1, 7].Value = "Designation";
                worksheet.Cells[1, 8].Value = "Department";

                // Add data rows
                for (int i = 0; i < users.Count; i++)
                {
                    var user = users[i];
                    worksheet.Cells[i + 2, 1].Value = user.UserId;
                    worksheet.Cells[i + 2, 2].Value = user.Email;
                    worksheet.Cells[i + 2, 3].Value = user.Name;
                    worksheet.Cells[i + 2, 4].Value = user.DateOfBirth.HasValue ? user.DateOfBirth.Value.ToShortDateString() : string.Empty;
                    worksheet.Cells[i + 2, 5].Value = user.BasicPay;
                    worksheet.Cells[i + 2, 6].Value = user.TotalEarnings;
                    worksheet.Cells[i + 2, 7].Value = user.Designation;
                    worksheet.Cells[i + 2, 8].Value = user.Department;
                }

                var stream = new MemoryStream();
                await package.SaveAsAsync(stream);
                stream.Position = 0;

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Users.xlsx");
            }
        }



        //--------------------------------------------------------------------------------------------------------------------------

        // GET: Admin/RequestManagement
        public async Task<IActionResult> RequestManagement(string status = "pending")
        {
            var requests = await _adminService.GetAllRequestsAsync();

            switch (status.ToLower())
            {
                case "accepted":
                    requests = requests.Where(r => r.isprocessed == Isprocessed.Accepted).OrderBy(r => r.RequestDate).ToList();
                    break;

                case "rejected":
                    requests = requests.Where(r => r.isprocessed == Isprocessed.Rejected).OrderBy(r => r.RequestDate).ToList();
                    break;

                case "pending":
                default:
                    requests = requests.Where(r => r.isprocessed == Isprocessed.Processing).OrderBy(r => r.RequestDate).ToList();
                    break;
            }

            ViewBag.CurrentStatus = status;
            return View(requests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptRequest(int requestId, string remarks)
        {
            try
            {
                var request = await _adminService.GetRequestByIdAsync(requestId);
                if (request != null)
                {
                    request.isprocessed = Isprocessed.Accepted;
                    request.Remarks = remarks; // Set remarks
                    await _adminService.UpdateRequestAsync(request);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error accepting request");
                ModelState.AddModelError("", $"An error occurred while accepting the request: {ex.Message}");
            }

            return RedirectToAction(nameof(RequestManagement), new { status = "pending" });
        }

        // POST: Admin/RejectRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectRequest(int requestId, string remarks)
        {
            try
            {
                var request = await _adminService.GetRequestByIdAsync(requestId);
                if (request != null)
                {
                    request.isprocessed = Isprocessed.Rejected;
                    request.Remarks = remarks; // Set remarks
                    await _adminService.UpdateRequestAsync(request);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error rejecting request");
                ModelState.AddModelError("", $"An error occurred while rejecting the request: {ex.Message}");
            }

            return RedirectToAction(nameof(RequestManagement), new { status = "pending" });
        }









    }
}
