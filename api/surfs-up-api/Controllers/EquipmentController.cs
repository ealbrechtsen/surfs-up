using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private static readonly List<Equipment> EquipmentList = new()
        {
            new Equipment ()
            {
                Id = 1, Name = "RayBan", Quantity = 2
            }
        };

        [HttpGet]
        public IActionResult GetAllEquipment()
        {
            return Ok(EquipmentList);
        }

        [HttpPost]
        public IActionResult AddEquipment([FromBody] Equipment equipment)
        {
            EquipmentList.Add(equipment);
            return CreatedAtAction(nameof(GetAllEquipment), new { name = equipment }, equipment);
        }
    }
}
