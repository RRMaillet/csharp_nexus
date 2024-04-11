using api_controller.Data;
using api_controller.Filters.ActionFilters;
using api_controller.Filters.ExceptionFilters;
using api_controller.Models;
using api_controller.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api_controller.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class FlooringController(ApplicationDBContext db) : ControllerBase
    {
        private readonly ApplicationDBContext db = db;

        [HttpGet]
        public IActionResult GetFloors()
        {
            return Ok(db.Floors.ToList());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(Floor_ValidateFloorIdFilterAttribute))]
        public IActionResult GetFloorById(int Id)
        {
            return Ok(HttpContext.Items["floor"]);
        }

        [HttpPost]
        [TypeFilter(typeof (Floor_ValidateCreateFloorFilterAttribute))]
        public IActionResult CreateFloor([FromBody] Floor floor)
        {
            
            db.Floors.Add(floor);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetFloorById), new {id = floor.FloorId}, floor);
        }

        [HttpPut("{id}")]
        [Floor_ValidateUpdateFloorFilter]
        [TypeFilter(typeof(Floor_ValidateFloorIdFilterAttribute))]
        [TypeFilter(typeof(Floor_HandleUpdateExceptionsFilterAttribute))]
        public IActionResult UpdateFloor(int Id, Floor floor)
        {
            var floorToUpdate = HttpContext.Items["floor"] as Floor;
            floorToUpdate.FloorName = floor.FloorName;
            floorToUpdate.FloorColor = floor.FloorColor;
            floorToUpdate.FloorDescription = floor.FloorDescription;
            floorToUpdate.Price = floor.Price;

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(Floor_ValidateFloorIdFilterAttribute))]
        public IActionResult DeleteFloor(int Id)
        {
            var floorToDelete = HttpContext.Items["floor"] as Floor;

            db.Floors.Remove(floorToDelete);
            db.SaveChanges();

            return Ok(floorToDelete);
        }
    }
}


