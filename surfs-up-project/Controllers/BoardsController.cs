using Microsoft.AspNetCore.Mvc;

namespace surfs_up_project.Controllers
{
    public class BoardsController : Controller
    {
        public IActionResult Board1()
        {
            return View();
        }

        public IActionResult Board2() {
            return View();
        }
    }
}
