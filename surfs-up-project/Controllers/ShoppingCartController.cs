using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;

namespace surfs_up_project.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            var items = ShoppingCart.GetItems();
            return View(items);
        }
    }
}
