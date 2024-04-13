using Microsoft.AspNetCore.Mvc;
using api_WebFront.Models;
using api_WebFront.Data;
using System.ComponentModel;

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
                try
                {
                    var response = await webApiExecuter.InvokePost("Flooring", floor);
                    if (response != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (WebApiException ex)
                {
                    HandleWebApiException(ex);
                }
            }
            return View(floor);
        }


        public async Task<IActionResult> UpdateFloor(int floorId)
        {
            try
            {
                var floor = await webApiExecuter.InvokeGet<Floor>($"flooring/{floorId}");

                if (floor != null)
                {
                    return View(floor);
                }
            }
            catch(WebApiException ex)
            {
                HandleWebApiException(ex);
                return View();
            }

            return NotFound();
            
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFloor(Floor floor)
        {
            if (ModelState.IsValid)
            {
                try { 
                await webApiExecuter.InvokePut($"Flooring/{floor.FloorId}", floor);
                return RedirectToAction(nameof(Index));
                }
                catch(WebApiException ex)
                {
                    HandleWebApiException(ex);
                }
            }
            return View(floor);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFloor(int floorId)
        {

            try 
            { 
                await webApiExecuter.InvokeDelete($"flooring/{floorId}");
                return RedirectToAction(nameof(Index));
            }
            catch(WebApiException ex)
            {
                HandleWebApiException(ex);
                return View(nameof(Index), await webApiExecuter.InvokeGet<List<Floor>>("flooring"));
            }


        }

        private void HandleWebApiException(WebApiException ex)
        {
            if (ex.ErrorResponse != null &&
                ex.ErrorResponse.Errors != null &&
                ex.ErrorResponse.Errors.Count > 0)
            {
                foreach (var message in ex.ErrorResponse.Errors)
                {
                    ModelState.AddModelError(message.Key, string.Join("; ", message.Value));
                }

            }
        }   
    }
}
