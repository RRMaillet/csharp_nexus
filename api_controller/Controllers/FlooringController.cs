using Microsoft.AspNetCore.Mvc;

namespace api_controller.Controllers

{
    [ApiController]
    public class FlooringController : ControllerBase
    {
        [HttpGet]
        public string GetFloors()
        {
            return "Reading all the floors...";
        }

        [HttpGet]
        public string GetFloorById(int id)
        {
            return $"Reading Floor with ID {id}";
        }

        [HttpGet]
        public string UpdateFloor(int id)
        {
            return $"Updating Floor with ID {id}";
        }

        [HttpGet]
        public string DeleteFloor(int id)
        {
            return $"Deleting Floor with ID {id}";
        }
    }
}


