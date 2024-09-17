using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;

namespace surfs_up_project.Controllers
{
    public class ShippingController : Controller
    {
        public IActionResult Index(DateTime pickUpDate, DateTime returnDate)
        {
            ShoppingCart.PickUpDate = pickUpDate;
            ShoppingCart.ReturnDate = returnDate;
            
            return View();
        }
    }
}
