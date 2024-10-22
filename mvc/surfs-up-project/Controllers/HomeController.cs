using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;

namespace surfs_up_api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
