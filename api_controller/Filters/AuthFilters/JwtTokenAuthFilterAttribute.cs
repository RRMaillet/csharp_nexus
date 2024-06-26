﻿using api_controller.Authority;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api_controller.Filters.AuthFilters
{
    public class JwtTokenAuthFilterAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token))
            {
                context.Result = new UnauthorizedResult();
                return;
            };

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            if (!Authenticator.VerifyToken(token, configuration.GetValue<string>("SecretKey")))
            {
                    context.Result = new UnauthorizedResult();
            };

            
        }
    }
}
