using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using api_controller.Models.Repositories;

namespace api_controller.Filters
{
    public class Floor_ValidateFloorIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var floorId = context.ActionArguments["id"] as int?;

            if (floorId.HasValue) 
            {
                if (floorId.Value <= 0) 
                {
                    context.ModelState.AddModelError("FloorId", "FloorId is invalid.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                else if (!FloorRepository.FloorExists(floorId.Value))
                {
                    context.ModelState.AddModelError("FloorId", "Floor does not exist.");
                    context.Result = new NotFoundObjectResult(context.ModelState);
                }
            }
        }
    }
}
