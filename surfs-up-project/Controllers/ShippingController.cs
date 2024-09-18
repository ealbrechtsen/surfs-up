using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;

namespace surfs_up_project.Controllers
{
    public class ShippingController : Controller
    {
        public IActionResult Index(DateTime pickUpDateTime, DateTime returnDateTime)
        {
            // Opdaterer afhentnings- og afleveringsdato med tidspunkter i indkøbskurven
            ShoppingCart.PickUpDate = pickUpDateTime;
            ShoppingCart.ReturnDate = returnDateTime;

            return View();
        }

    }
}
