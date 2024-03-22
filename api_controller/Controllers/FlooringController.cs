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
            return Ok("Reading all the floors...");
        }

        [HttpGet("{id}")]
        [Floor_ValidateFloorIdFilter]
        public IActionResult GetFloorById(int id)
        {
            
            return Ok(FloorRepository.GetFloorById(id));
        }

        [HttpPost]
        public IActionResult CreateFloor([FromBody] Floor floor)
        {
            return Ok($"Creating a floor!");
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


