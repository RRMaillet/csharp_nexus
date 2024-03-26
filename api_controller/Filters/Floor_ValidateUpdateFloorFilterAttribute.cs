using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using api_controller.Models;

namespace api_controller.Filters
{
    public class Floor_ValidateUpdateFloorFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var floor = context.ActionArguments["floor"] as Floor;

            if (id.HasValue && floor != null && id != floor.FloorId)
            {
                context.ModelState.AddModelError("FloorId", "FloorId is note the same as id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
