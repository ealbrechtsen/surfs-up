using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;

namespace surfs_up_project.Controllers
{
    public class ShippingController : Controller
    {
        private ShoppingCart _shoppingCart = new ShoppingCart();

        public IActionResult Index(DateTime pickUpDateTime, DateTime returnDateTime)
        {
            // Opdaterer afhentnings- og afleveringsdato med tidspunkter i indkøbskurven
            _shoppingCart.PickUpDate = pickUpDateTime;
            _shoppingCart.ReturnDate = returnDateTime;

            return View();
        }

    }
}
