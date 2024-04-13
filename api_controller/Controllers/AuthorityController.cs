using api_controller.Authority;
using Microsoft.AspNetCore.Mvc;


namespace api_controller.Controllers
{   

    [ApiController]
    public class AuthorityController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthorityController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody]AppCredential credential)
        {
            if (Authenticator.Authenticate(credential.ClientId, credential.ClientSecret))
            {

                var expiresAt = DateTime.UtcNow.AddMinutes(10);

                return Ok(new
                {
                    access_token = Authenticator.CreateToken(credential.ClientId, expiresAt, configuration.GetValue<string>("SecretKey")),
                    expires_At = expiresAt
                });
            }
            else 
            {
                ModelState.AddModelError("Unauthorized", "Your are not authorized to access");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status401Unauthorized
                };

                return new UnauthorizedObjectResult(problemDetails);
            }
            
        }

       
    }
}
