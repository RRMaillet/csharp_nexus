using api_controller.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_controller.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class FlooringController : ControllerBase
    {
        private List<Floor> floors = new List<Floor>()
        {
            new Floor{ FloorId= 12, FloorName="Laminate", FloorColor="Beige", FloorDescription="Beige Laminate Floor", Price=1.53},
            new Floor{ FloorId= 15, FloorName="Cork", FloorColor="Brown", FloorDescription="Brown Cork Floor", Price=2.10},
            new Floor{ FloorId= 18, FloorName="Leather", FloorColor="Black", FloorDescription="Black Leather Floor", Price=4.53},
            new Floor{ FloorId= 19, FloorName="Wood", FloorColor="Green", FloorDescription="Green Wood Floor", Price=2.99},
            new Floor{ FloorId= 21, FloorName="Polycarbonate", FloorColor="Clear", FloorDescription="Clear Polycarbonate Floor", Price=0.95}
        };



        [HttpGet]
        public IActionResult GetFloors()
        {
            return Ok("Reading all the floors...");
        }

        [HttpGet("{id}")]
        public IActionResult GetFloorById(int id)
        {
            if (id <= 0) return BadRequest(id.ToString());

            var floor = floors.FirstOrDefault(x => x.FloorId == id);

            if (floor == null)
            {
                return NotFound();
            }

            return Ok(floor);
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


