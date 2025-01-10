using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using surfs_up_api.Models;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly AppDbContext _context;

        // POST: api/rental/boards
        [HttpPost("boards")]
        public IActionResult PostBoards([FromBody] List<Product> products)
        {
            if (products == null || !products.Any())
            {
                // Return 400 Bad Request, if hvis input is invalid
                return BadRequest(new { message = "Product list cannot be null or empty" });
            }

            try
            {
                // Empty database of existing boards
                _context.Products.RemoveRange(_context.Products);
                _context.SaveChanges();

                // Add new boards to database
                _context.Products.AddRange(products);
                _context.SaveChanges();

                // Return added products with 201 Created
                return CreatedAtAction(nameof(GetBoards), new { count = products.Count }, products);
            }
            catch (Exception ex)
            {
                // Hvis der opstår en fejl, returnér 500 Internal Server Error
                return StatusCode(500, new { message = "An error occurred while saving the boards", details = ex.Message });
            }
        }

        // GET: api/rental/boards
        [HttpGet("boards")]
        public IActionResult GetBoards()
        {
            // Get all boards from database
            var boards = _context.Products.ToList();
            if (boards == null || !boards.Any())
            {
                // Return 404 Not Found, if no boards are found
                return NotFound(new { message = "No boards found" });
            }
            // Return all boards with as JSON with 200 OK
            return Ok(boards);
        }

        public RentalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/rental/board/{id}
        [HttpGet("board/{id}")]
        public async Task<IActionResult> GetBoard(int id)
        {
            // Find produktet baseret på ID
            var board = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id && p.Type == "Board");

            // Tjek om produktet blev fundet
            if (board == null)
            {
                return NotFound(new { message = $"Board with ID {id} not found" });
            }

            // Returner produktet som JSON
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
