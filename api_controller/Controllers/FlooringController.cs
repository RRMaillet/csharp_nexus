using api_controller.Filters.ActionFilters;
using api_controller.Filters.ExceptionFilters;
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

        [HttpPut("{id}")]
        [Floor_ValidateFloorIdFilter]
        [Floor_ValidateUpdateFloorFilter]
        [Floor_HandleUpdateExceptionsFilter]
        public IActionResult UpdateFloor(int id, Floor floor)
        {
            FloorRepository.UpdateFloor(floor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Floor_ValidateFloorIdFilter]
        public IActionResult DeleteFloor(int id)
        {
            var floor = FloorRepository.GetFloorById(id);
            FloorRepository.RemoveFloor(id);

            return Ok(floor);
        }
    }
}


