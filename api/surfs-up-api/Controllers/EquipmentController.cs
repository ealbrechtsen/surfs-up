using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private static readonly List<Equipment> equipments = new List<Equipment>()
        {
            new Equipment{ Id = 1, Name = "Rayban", Quantity = 99}
        };

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(equipments);
        }

        [HttpPost]
        public IActionResult Add(Equipment equipment)
        {
            equipments.Add(equipment);
            return CreatedAtAction(nameof(GetAll), new {id = equipment.Id}, equipment);
        }
    }
}
