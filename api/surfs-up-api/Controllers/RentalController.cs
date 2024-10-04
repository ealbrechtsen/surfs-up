using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        // GET: api/rental/boards
        [HttpGet("boards")]
        public IActionResult GetBoards()
        {
            var boards = ProductRepository.GetProducts();
            if (boards == null || !boards.Any())
            {
                return NotFound(new { message = "No boards found" });
            }
            return Ok(boards);
        }

        // GET: api/rental/board/{id}
        [HttpGet("board/{id}")]
        public IActionResult GetBoard(int? id)
        {
            if (id == null)
            {
                return BadRequest(new { message = "Board ID is required" });
            }

            var board = ProductRepository.GetProductById(id);
            if (board == null)
            {
                return NotFound(new { message = $"Board with ID {id} not found" });
            }

            return Ok(board);
        }

        // GET: api/rental/wetsuit/{id}
        [HttpGet("wetsuit/{id}")]
        public IActionResult GetWetsuit(int? id)
        {
            if (id == null)
            {
                return BadRequest(new { message = "Wetsuit ID is required" });
            }

            var wetsuit = ProductRepository.GetProductById(id);
            if (wetsuit == null)
            {
                return NotFound(new { message = $"Wetsuit with ID {id} not found" });
            }

            return Ok(wetsuit);
        }

        // GET: api/rental/equipment/{id}
        [HttpGet("equipment/{id}")]
        public IActionResult GetEquipment(int? id)
        {
            if (id == null)
            {
                return BadRequest(new { message = "Equipment ID is required" });
            }

            var equipment = ProductRepository.GetProductById(id);
            if (equipment == null)
            {
                return NotFound(new { message = $"Equipment with ID {id} not found" });
            }

            return Ok(equipment);
        }
    }
}
