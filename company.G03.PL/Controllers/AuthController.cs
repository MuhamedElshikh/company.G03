using Castle.Core.Smtp;
using company.G03.PL.Models;
using company.G03.PL.Models.Auth;
using company.G03.PL.Views.Auth;
using company.G3.DLL.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace company.G03.PL.Controllers
{
    public class AuthController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager ) : Controller
    {
        public IActionResult Register() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel User)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = User.UserName,
                    Email = User.Email,
                    FirstName = User.FirstName,
                    LastName = User.LastName
                };
                var result = _userManager.CreateAsync(user, User.Password).Result;
                if (result.Succeeded)
                {
                    //await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {

                        ModelState.AddModelError("", error.Description);

                    }

                }


            }

            return View(User);
        }
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user is not null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                    if (result)
                    {
                        var Result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);
                        if (Result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(loginViewModel);

        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetViewModel resetViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(resetViewModel.Email);

                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var RestPasswordLink = Url.Action("ForgetPassword", "Auth", new { email = resetViewModel.Email,token }, Request.Scheme);
                    var Email = new ResetPasswordViewModel()
                    {
                        To = resetViewModel.Email,
                        Subject = "Reset Password",
                        Body= RestPasswordLink
                    };
                    EmailSender.SendEmail(Email);
                    return RedirectToAction("EmailSent" ,resetViewModel);
                    // Send email logic here
                    // For example, using an email service to send the email
                    // You can also generate a password reset token and send it in the email


                    //
                    //var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordViewModel.Password);
                    //if (result.Succeeded)
                    //{
                    //    
                    //}
                    //ModelState.AddModelError("", "Invalid email address.");


                }
                
            }
            ModelState.AddModelError("", "Invalid email address.");
            return View(resetViewModel);
        }
        public IActionResult EmailSent(ResetViewModel resetViewModel)
        {
            return View(resetViewModel);
        }
        public IActionResult ForgetPassword(string email, string token)
        {
            TempData ["Email"] = email;
            TempData ["Token"] = token;
            return View();
        }
        [HttpPost]

        public async Task< IActionResult> ForgetPassword(ForgetPasword forgetPasword)
        {
            var email = TempData["Email"] as string;
            var token = TempData["Token"] as string;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError("", "Invalid email address or token.");
                return RedirectToAction("Login");
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) { 
            ModelState.AddModelError("", "Invalid email address.");
                return RedirectToAction("Login");
            }
            var result = await _userManager.ResetPasswordAsync(user, token, forgetPasword.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else { 
            foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ForgetPasswor", forgetPasword);
            }
        }
    }
}
