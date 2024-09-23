using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;
using surfs_up_project.Models.ViewModels;
using System.Reflection.Metadata;

namespace surfs_up_project.Controllers
{
    public class AccountController : Controller
    {  
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        // This method handles GET requests to render the login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        // This method handles POST requests for login form submission
        [HttpPost]
        public async Task<IActionResult> Login (LoginVM model)
        { 
            if(ModelState.IsValid)
            {
                //login
                var result = await signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Forkert Brugernavn eller adgangskode");
                return View(model);


            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
                    Address = model.Address,
                    ZipCode = model.ZipCode,
                    City = model.City

                };
                var result = await userManager.CreateAsync(user, model.Password!);
                if (result.Succeeded)
                { 
                    await signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        public async Task <IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
