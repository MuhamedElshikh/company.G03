using company.G03.PL.Models.Auth;
using company.G3.DLL.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace company.G03.PL.Controllers
{
    public class AuthController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager) : Controller
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
                if (user is not  null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                    if (result)
                    {
                      var Result =  await _signInManager.PasswordSignInAsync(user,loginViewModel.Password ,loginViewModel.RememberMe,false);
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
        

        public async Task< IActionResult> Logout()
        {
          await  _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
