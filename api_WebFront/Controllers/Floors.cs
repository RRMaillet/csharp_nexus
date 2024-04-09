using Microsoft.AspNetCore.Mvc;
using api_WebFront.Models.Repositories;

namespace api_WebFront.Controllers
{
    public class Floors : Controller
    {
        public IActionResult Index()
        {
            return View(FloorRepository.GetAllFloors());
        }
    }
}
