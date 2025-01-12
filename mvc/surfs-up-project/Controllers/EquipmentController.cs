using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;

namespace surfs_up_project.Controllers
{
    public class EquipmentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                // Process valid data
                return RedirectToAction("Success");
            }
            return View(equipment);
        }

        public IActionResult Success()
        {
            return Content("Equipment added successfully!");
        }
    }
}
