using Employemanagement_22_8_24.Data.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Employemanagement_22_8_24.Controllers
{
    public class UserController : Controller
    {
        private readonly IUSERSERVICE _userService;

        public UserController(IUSERSERVICE  userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult> UserDashboard(string userId)
        {
            var userDetails = _userService.GetUserDetailsAsync(userId);
            return View(userDetails);
        }

        public async Task<IActionResult> ViewRequests()
        {
            // Retrieve the current user ID from the session
            string currentUserId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(currentUserId))
            {
                // Handle the case where the user ID is not found in the session
                return RedirectToAction("Login", "Account"); // Redirect to login page or an appropriate action
            }
            try
            {
                // Use the service to get all requests for the current user
                var requests = await _userService.GetAllRequestsByUserIdAsync(currentUserId);

                // Return the view with the list of requests
                return View(requests);
            }
            catch (Exception ex)
            {
                // Handle any errors that might have occurred
                ModelState.AddModelError("", $"An error occurred while retrieving requests: {ex.Message}");
                return View("Error"); // Return an error view or appropriate response
            }
        }

        // POST: User/DeleteRequest/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            try
            {
                await _userService.DeleteRequestAsync(id);
                return RedirectToAction(nameof(ViewRequests));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred while deleting the request: {ex.Message}");
                return RedirectToAction(nameof(ViewRequests));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        // GET: User/AddRequest
        public IActionResult AddRequest()
        {
            return View();
        }

        // POST: User/AddRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRequest(string editRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Get the current user's ID from session
                    string currentUserId = HttpContext.Session.GetString("UserId");

                    if (string.IsNullOrEmpty(currentUserId))
                    {
                        throw new Exception("User ID not found in session.");
                    }

                    // Add the request using the service method
                    await _userService.AddRequestAsync(currentUserId, editRequest);

                    // Redirect to the ViewRequests page after successful addition
                    return RedirectToAction(nameof(ViewRequests));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred while adding the request: {ex.Message}");
                }
            }
            return View();
        }



    }
}
