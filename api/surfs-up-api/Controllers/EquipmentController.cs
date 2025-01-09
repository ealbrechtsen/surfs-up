using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            // Simulér at gemme data
            Console.WriteLine($"Equipment gemt: {equipment.Name}, {equipment.Type}, {equipment.Price}");
            return Ok(equipment);
        }
    }
}
