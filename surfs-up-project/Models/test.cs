using Microsoft.AspNetCore.Mvc;

namespace surfs_up_project.Models
{
    public class test : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
