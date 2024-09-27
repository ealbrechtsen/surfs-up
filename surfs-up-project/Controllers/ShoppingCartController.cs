using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;


namespace surfs_up_project.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            List<ShoppingCartItem> items = ShoppingCart.GetItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity = 1)
        {
            // Get the referer (previous URL) from the request headers
            var refererUrl = HttpContext.Request.Headers["Referer"].ToString();

            // Parse the referer URL using the Uri class
            Uri refererUri = new Uri(refererUrl);

            // Extract the path from the URL
            string refererPath = refererUri.AbsolutePath;

            var product = ProductRepository.GetProductById(productId);
            if (product != null)
            {
                ShoppingCart.AddItem(product, quantity);
            }

            // if (refererPath.Contains("boards"))
            // {
            //     var boards = ProductRepository.GetProducts();
            //     return View("~/Views" + refererPath + ".cshtml", boards);
            // }
            // else if (refererPath.Contains("board"))
            // {
            //     var board = ProductRepository.GetProductById(productId);
            //     return View(board);
            // }
            // else
            // {
            //     return View("~/Views" + refererPath + ".cshtml");
            // }
            List<ShoppingCartItem> items = ShoppingCart.GetItems();
            return View("Index", items);
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            ShoppingCart.DeleteItem(id);
            List<ShoppingCartItem> items = ShoppingCart.GetItems();
            return View("Index", items);
        }
    }
}
