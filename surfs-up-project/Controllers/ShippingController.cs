using Microsoft.AspNetCore.Mvc;

namespace surfs_up_project.Controllers
{
    public class ShippingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
