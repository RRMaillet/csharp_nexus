using Microsoft.AspNetCore.Mvc;
using api_WebFront.Models;
using api_WebFront.Data;

namespace api_WebFront.Controllers
{
    public class FloorsController : Controller
    {
        private readonly IWebApiExecuter webApiExecuter;

        public FloorsController(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }
        public async Task<IActionResult> Index()
        {
            return View(await webApiExecuter.InvokeGet<List<Floor>>("flooring"));
        }

        public IActionResult CreateFloor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFloor(Floor floor)
        {
            if (ModelState.IsValid)
            {
                var response = await webApiExecuter.InvokePost("Flooring", floor);
                if (response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(floor);
        }


        public async Task<IActionResult> UpdateFloor(int floorId)
        {
            var floor = await webApiExecuter.InvokeGet<Floor>($"flooring/{floorId}");

            if (floor != null)
            {
                return View(floor);
            }

            return NotFound();
            
            
        }

    }
}
