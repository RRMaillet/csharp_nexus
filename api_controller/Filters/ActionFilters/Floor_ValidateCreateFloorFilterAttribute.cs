using api_controller.Models.Repositories;
using api_controller.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace api_controller.Filters.ActionFilters
{
    public class Floor_ValidateCreateFloorFilterAttribute : ActionFilterAttribute
    {
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
                var existingFloor = FloorRepository.GetFloorByProperties(floor.FloorName, floor.FloorColor);
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
