using Microsoft.AspNetCore.Mvc;

namespace api_controller.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class FlooringController : ControllerBase
    {
        [HttpGet]
        public string GetFloors()
        {
            return "Reading all the floors...";
        }

        [HttpGet("{id}")]
        public string GetFloorById(int id)
        {
            return $"Reading Floor with ID {id}";
        }

        [HttpPost("{id}")]
        public string UpdateFloor(int id)
        {
            return $"Updating Floor with ID {id}";
        }

        [HttpDelete("{id}")]
        public string DeleteFloor(int id)
        {
            return $"Deleting Floor with ID {id}";
        }
    }
}


