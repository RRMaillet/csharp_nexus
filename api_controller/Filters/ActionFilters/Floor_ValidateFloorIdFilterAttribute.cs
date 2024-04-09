using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using api_controller.Data;

namespace api_controller.Filters.ActionFilters 
{ 

    public class Floor_ValidateFloorIdFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDBContext db;

        public Floor_ValidateFloorIdFilterAttribute(ApplicationDBContext db)
        {
            this.db = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var floorId = context.ActionArguments["id"] as int?;

            if (floorId.HasValue) 
            {
                
                if (floorId.Value <= 0) 
                {
                    context.ModelState.AddModelError("FloorId", "FloorId is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else
                {
                    var floorIdExsits = db.Floors.Find(floorId.Value);

                    if (floorIdExsits == null)
                    {

                        context.ModelState.AddModelError("FloorId", "Floor does not exist.");
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problemDetails);
                    }
                    else
                    {
                        context.HttpContext.Items["floor"] = floorIdExsits;
                    }

                }


            }
        }
    }
}
