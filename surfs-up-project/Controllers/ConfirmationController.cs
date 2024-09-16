using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;

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
