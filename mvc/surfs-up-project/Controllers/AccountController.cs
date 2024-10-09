using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Til konvertering af objekter til JSON og omvendt
using surfs_up_project.Models.ViewModels; // Importér dine ViewModels

namespace surfs_up_project.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Lav POST-request til API'en
            var response = await _httpClient.PostAsync("https://yourapiurl.com/api/account/login", content);

            if (response.IsSuccessStatusCode)
            {
                // Håndterer succesfuld login, fx opret session eller modtag JWT-token fra API'en
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Forkert brugernavn eller adgangskode");
            return View(model);
        }

        // GET: Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Lav POST-request til API'en
            var response = await _httpClient.PostAsync("https://yourapiurl.com/api/account/register", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            // Håndter eventuelle fejl fra API'en
            var errorResult = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, errorResult);
            return View(model);
        }

        // POST: Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Lav POST-request til API'en for at logge ud
            var response = await _httpClient.PostAsync("https://yourapiurl.com/api/account/logout", null);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            // Håndter eventuelle fejl fra API'en
            return RedirectToAction("Index", "Home");
        }
    }
}
