using _3_Auth_Module_AtoZ.Services;
using _3_Auth_Module_AtoZ.ViewModel;
using DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _3_Auth_Module_AtoZ.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EmailService _emailService;

        public AccountController(UserManager<ApplicationUser> userManager
                            ,SignInManager<ApplicationUser> signInManager
                            ,EmailService _emailService
                            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._emailService = _emailService;
        }

        //------------------------------------------------
        //_________________ 1.  Registration + Confirm Email _____________
        //------------------------------------------------
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            //    var result = await _userManager.CreateAsync(user, model.Password);

            //    if (result.Succeeded)
            //    {
            //        // Automatically sign in the user after registration
            //        await _signInManager.SignInAsync(user, isPersistent: false);
            //        return RedirectToAction("Index","Home");
            //    }

            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(string.Empty, error.Description);
            //    }
            //}

            //return View(model);
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                    await _emailService.SendConfirmationEmail(user.Email, confirmationLink);

                    return RedirectToAction("EmailConfirmationSent");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult EmailConfirmationSent()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View("EmailConfirmed");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("Error");
        }

        public IActionResult EmailConfirmed()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        //------------------------------------------------
        //_________________ 2. Login + Check EmailConfirm _____________________
        //------------------------------------------------
        //set forget password link  in  View
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            //if (ModelState.IsValid)
            //{
            //    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            //    if (result.Succeeded)
            //    {
            //        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            //        {
            //            return Redirect(returnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }

            //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            //}
            //return View(model);
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null && !await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "You need to confirm your email before logging in.");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        //------------------------------------------------
        //_________________ 3. LogOut ____________________
        //------------------------------------------------
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        //------------------------------------------------
        //_________________ 3. Forget Password / Reset Password____________________
        //------------------------------------------------
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            var ForgotPasswordViewModel = new ForgotPasswordViewModel();
            return View(ForgotPasswordViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // User not found or email not confirmed
                    ViewBag.Error = "Error";
                    ViewBag.User = "Invalid Email";
                    return View(model);
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                // Send the password reset email
                await _emailService.SendPasswordResetEmail(model.Email, callbackUrl);

                return RedirectToAction("ForgotPasswordConfirmation");
            }
            ViewBag.Error = "Error";
            // Invalid model state, redisplay the form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPasswordJs(string Email)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // User not found or email not confirmed
                    ViewBag.Error = "Error";
                    ViewBag.User = "Invalid Email";
                    return View();
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                // Send the password reset email
                await _emailService.SendPasswordResetEmail(Email, callbackUrl);

                return RedirectToAction("ForgotPasswordConfirmation");
            }
            ViewBag.Error = "Error";
            // Invalid model state, redisplay the form
            return View();
        }


        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //------------------------------------------------
        //_________________ 4. Reset Password in Gmail  ____________________
        //------------------------------------------------
        [HttpGet]
        public IActionResult ResetPassword(string token, string userId)
        {
            if (token == null || userId == null)
            {
                // Invalid token or user ID
                return RedirectToAction("Error");
            }

            var model = new ResetPasswordViewModel { Token = token, UserId = userId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    // User not found
                    ViewBag.Error = "Error";
                    return RedirectToAction("Error");
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    // Password reset successful
                    return RedirectToAction("ResetPasswordConfirmation");
                }

                // If there are any errors, add them to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Invalid model state, redisplay the form
            return View(model);
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }


    }
}
