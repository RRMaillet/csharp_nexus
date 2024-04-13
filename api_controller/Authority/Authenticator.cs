using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace api_controller.Authority
{
    public static class Authenticator
    {
        public static bool Authenticate(string clientId, string clientSecret)
        {
            var application = AppRepository.GetApplicationByClientId(clientId);
            if (application == null) return false;

            return (application.ClientId == clientId && application.ClientSecret == clientSecret);

        }

        public static string CreateToken(string clientId, DateTime expiresAt, string strSecretKey)
        {
            //Algorithm to create token

            //Payload contains client id and expiry time

            //Signing Key

            var app = AppRepository.GetApplicationByClientId(clientId);

            var claims = new List<Claim>
            {
                new Claim("AppName", app?.AppName??string.Empty),
                new Claim("Read", (app?.Scopes??string.Empty).Contains("read")? "true":"false"),
                new Claim("Write", (app?.Scopes??string.Empty).Contains("write")? "true":"false")
            };

            var secretKey = Encoding.ASCII.GetBytes(strSecretKey);

            var jwt = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature
                    ),
                claims: claims,
                expires: expiresAt,
                notBefore: DateTime.UtcNow
                );

            //Generated Signature
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public static bool VerifyToken(string token, string strSecretKey)
        {
            if (string.IsNullOrWhiteSpace(token)) return false;

            var secretKey = Encoding.ASCII.GetBytes(strSecretKey);

            SecurityToken securityToken;

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                }, out securityToken);
            }
            catch(SecurityTokenException)
            {
                return false;
            }
            catch
            {
                throw;
            }

            return securityToken != null;
        }
    }
}
