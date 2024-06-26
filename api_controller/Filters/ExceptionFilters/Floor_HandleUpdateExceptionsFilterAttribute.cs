﻿using api_controller.Data;
using api_controller.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api_controller.Filters.ExceptionFilters
{
    public class Floor_HandleUpdateExceptionsFilterAttribute: ExceptionFilterAttribute
    {
        private readonly ApplicationDBContext db;

        public Floor_HandleUpdateExceptionsFilterAttribute(ApplicationDBContext db)
        {
            this.db = db;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strFloorId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strFloorId, out int floorId))
            {
                if (db.Floors.FirstOrDefault(x => x.FloorId == floorId) == null)
                {
                    context.ModelState.AddModelError("Floor", "Floor Id does not exist anymore!");
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
