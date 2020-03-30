using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScheduleGenerator.Models;
using ScheduleGenerator.Models.ViewModels;

namespace ScheduleGenerator.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public HomeController(UserManager<AppUser> userMgr, SignInManager<AppUser> singInMgr)
        {
            userManager = userMgr;
            signInManager = singInMgr;
        }
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { 
            ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(loginModel.Name);

                
                if (user != null)
                {
                    if ((await signInManager.PasswordSignInAsync(user,
                        loginModel.Password, false, false)).Succeeded)
                    {
                        if ((await userManager.IsInRoleAsync(user, "ADMIN")))
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/Home/Index");
                        }
                        else if ((await userManager.IsInRoleAsync(user, "COORDINATOR")))
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/Home/Index2");
                        }
                        else if ((await userManager.IsInRoleAsync(user, "INSTRUCTOR")))
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/Home/Index3");
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Index2()
        {
            return View();
        }

        public ViewResult Index3()
        {
            return View();
        }

    }
}
