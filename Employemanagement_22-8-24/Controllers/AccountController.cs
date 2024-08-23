using Employemanagement_22_8_24.Data.Services;
using Employemanagement_22_8_24.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employemanagement_22_8_24.Controllers
{
    public class AccountController : Controller
    {
        private readonly IACCOUNTSERVICE _accountService;

        public AccountController(IACCOUNTSERVICE accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Login model)
        {
            string returnUrl = Request.Query["ReturnUrl"]; // Ensure returnUrl is declared here

            if (ModelState.IsValid)
            {
                if (await _accountService.ValidateLoginAsync(model.UserId, model.Password))
                {
                    HttpContext.Session.SetString("UserId", model.UserId);

                    if (await _accountService.IsFirstTimeLoginAsync(model.UserId))
                    {
                        return RedirectToAction("UpdatePassword", new { userId = model.UserId });
                    }

                    var role = await _accountService.GetUserRoleAsync(model.UserId);
                    if (role == "Admin")
                    {
                        var localUrl = Url.Action("Admindashboard", "Admin");
                        return LocalRedirect(returnUrl ?? localUrl);



                    }
                    else
                    {
                        return RedirectToAction("UserDashboard", "User", new { userId = model.UserId });
                    }
                }

                ModelState.AddModelError("", "Invalid User ID or Password");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult UpdatePassword(string userId)
        {
            var model = new UpdatePassword { UserId = userId };
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdatePassword(UpdatePassword model)
        {
            if (true)
            {
                _accountService.UpdatePasswordAsync(model.UserId, model.ConfirmPassword);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPassword model)
        {

            
            
                 await _accountService.ForgotPasswordAsync(model.UserId);
                return RedirectToAction("ValidateOtp", new { userId = model.UserId });
            
            return View(model);
        }

        [HttpGet]
        public ActionResult ValidateOtp(string userId)
        {
            var model = new ValidateOtp { UserId = userId };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ValidateOtp(ValidateOtp model)
        {
            if (true)
            {
                if (await _accountService.ValidateOtpAsync(model.UserId, model.Otp))
                {
                    return RedirectToAction("UpdatePassword", new { userId = model.UserId });
                }

                ModelState.AddModelError("", "Invalid OTP");
            }
            return View(model);
        }
    }
}
