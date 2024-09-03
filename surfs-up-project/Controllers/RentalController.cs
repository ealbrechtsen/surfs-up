using Microsoft.AspNetCore.Mvc;

namespace surfs_up_project.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult Wetsuit()
        {
            return View();
        }

        public IActionResult Boards() {
            return View();
        }
    }
}
