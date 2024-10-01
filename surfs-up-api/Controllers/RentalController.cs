using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : Controller
    {
        [HttpGet]
        public IActionResult Boards()
        {
            var boards = ProductRepository.GetProducts();
            return Ok(boards);
        }

        [HttpGet("{id}")]
        public IActionResult Board(int? id)
        {
            var board = ProductRepository.GetProductById(id);
            return Ok(board);
        }

        //[HttpGet("{id}")]
        //public IActionResult Wetsuit(int? id)
        //{
        //    var board = ProductRepository.GetProductById(id);
        //    return Ok(board);
        //}

        //[HttpGet("{id}")]
        //public IActionResult Equipment(int? id)
        //{
        //    var board = ProductRepository.GetProductById(id);
        //    return Ok(board);
        //}
    }
}
