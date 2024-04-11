using api_controller.Models.Repositories;
using api_controller.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using api_controller.Data;

namespace api_controller.Filters.ActionFilters
{
    public class Floor_ValidateCreateFloorFilterAttribute(ApplicationDBContext db) : ActionFilterAttribute
    {
        private readonly ApplicationDBContext db = db;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var floor = context.ActionArguments["floor"] as Floor;

            if (floor == null)
            {
                context.ModelState.AddModelError("floor", "Floor object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };

                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingFloor = db.Floors.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.FloorName) && 
                                                                  !string.IsNullOrWhiteSpace(floor.FloorName) && 
                                                                  x.FloorName.ToLower() == floor.FloorName.ToLower() && 
                                                                  !string.IsNullOrWhiteSpace(x.FloorColor) && 
                                                                  !string.IsNullOrWhiteSpace(floor.FloorColor) && 
                                                                  x.FloorColor.ToLower() == floor.FloorColor.ToLower());

                if (existingFloor != null)
                {
                    context.ModelState.AddModelError("floor", "Floor object already exists");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }



        }
    }
}
