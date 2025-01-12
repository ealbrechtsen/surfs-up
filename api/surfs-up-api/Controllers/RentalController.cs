using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using surfs_up_api.Models;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly AppDbContext _context;

        private void EmptyDB()
        {
            _context.Products.RemoveRange(_context.Products);
            _context.SaveChanges();
        }

        // POST: api/rental/boards
        [HttpPost("boards")]
        public IActionResult PostBoards([FromBody] List<Product> products)
        {
            if (products.IsNullOrEmpty())
            {
                return BadRequest();
            }

            EmptyDB();

            try
            {
                _context.Products.AddRange(products);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return CreatedAtAction(nameof(PostBoards), products);
        }

        // GET: api/rental/boards
        [HttpGet("boards")]
        public IActionResult GetBoards()
        {
            var boards = _context.Products.ToList();
            if (boards.IsNullOrEmpty())
            {
                return NotFound();
            }
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
