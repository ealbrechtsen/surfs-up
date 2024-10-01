using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;

namespace surfs_up_project.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult Boards()
        {
            var boards = ProductRepository.GetProducts();
            return View(boards);
        }

        public IActionResult Board(int? id)
        {
            var board = ProductRepository.GetProductById(id);
            return View(board);
        }

        public IActionResult Wetsuit(int? id)
        {
            var board = ProductRepository.GetProductById(id);
            return View(board);
        }

        public IActionResult Equipment(int? id)
        {
            var board = ProductRepository.GetProductById(id);
            return View(board);
        }
    }
}
