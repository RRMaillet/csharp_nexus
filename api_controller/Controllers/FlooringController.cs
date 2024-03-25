using api_controller.Filters;
using api_controller.Models;
using api_controller.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api_controller.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class FlooringController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFloors()
        {
            return Ok(FloorRepository.GetAllFloors());
        }

        [HttpGet("{id}")]
        [Floor_ValidateFloorIdFilter]
        public IActionResult GetFloorById(int id)
        {
            
            return Ok(FloorRepository.GetFloorById(id));
        }

        [HttpPost]
        [Floor_ValidateCreateFloorFilter]
        public IActionResult CreateFloor([FromBody] Floor floor)
        {
            FloorRepository.AddFloor(floor);
            return CreatedAtAction(nameof(GetFloorById), new {id = floor.FloorId}, floor);
        }

        [HttpPost("{id}")]
        public IActionResult UpdateFloor(int id)
        {
            return Ok($"Updating Floor with ID {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFloor(int id)
        {
            return Ok($"Deleting Floor with ID {id}");
        }
    }
}


