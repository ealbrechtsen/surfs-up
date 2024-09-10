using Microsoft.AspNetCore.Mvc;

namespace surfs_up_project.Controllers
{
    public class ConfirmationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
