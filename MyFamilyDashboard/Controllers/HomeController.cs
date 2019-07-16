using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyFamilyDashboard.Data;
using MyFamilyDashboard.Models;

namespace MyFamilyDashboard.Controllers
{
    public class HomeController : Controller
    {
        protected ApplicationDbContext dbContext;
        protected UserManager<ApplicationUser> userManager;
        protected SignInManager<ApplicationUser> signInManager;
        public HomeController(ApplicationDbContext context, 
                              UserManager<ApplicationUser> uManager,
                              SignInManager<ApplicationUser> sIManager)
        {
            dbContext = context;
            userManager = uManager;
            signInManager = sIManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("create")]
        public async Task<IActionResult> CreateUserAsync()
        {
            var successful = await userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Gonyf",
                Email = "qzw@live.dk"
            },"Password.123");
            if (successful.Succeeded)
            {
                return Content("User was created", "text/html");
            }
            else
            {
                return Content("User creation failed", "text/html");
            }
        }

        // cookie authorization
        [Authorize]
        [Route("private")]
        public IActionResult Private()
        {
            return Content($"This is a private area. Welcome {HttpContext.User.Identity.Name}", "text/html");
        }

        [Route("login")]
        public async Task<IActionResult> Login(/*string returnUrl*/)
        {
            await signInManager.PasswordSignInAsync("gonyf", "Password.123", false, false);

            return Content("testing");
        }
        [Route("NotLoggedIn")]
        public async Task<IActionResult> LoginFailure(/*string returnUrl*/)
        {
            //await signInManager.PasswordSignInAsync("gonyf", "Password.123", false, false);

            return Content("loginFailed");
        }
        [Route("logout")]
        public async Task<IActionResult> LogOut(/*string returnUrl*/)
        {
            await signInManager.SignOutAsync();

            return Content("testing");
        }
    }
}
