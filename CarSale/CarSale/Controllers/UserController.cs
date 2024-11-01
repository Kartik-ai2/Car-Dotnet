using CarSale.Models;
using Entities.Dbset;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("Login")]
        public IActionResult Login(string username, string password)
        {
            /* var expirationTime = DateTime.UtcNow.AddHours(1);
             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.UTF8.GetBytes("MyVerySecureSecretKey1234567890!");
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new[]
                 {
         new Claim("unique_name", "12345"),
         new Claim("UserId", "12345"),
         new Claim("RoleName", "Admin"),
         new Claim("RoleId", "1"),
          new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expirationTime).ToUnixTimeSeconds().ToString())
     }),
                 Expires = DateTime.UtcNow.AddHours(1),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
             };
             var token = tokenHandler.CreateToken(tokenDescriptor);
             string tokenString = tokenHandler.WriteToken(token);
             var tokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyVerySecureSecretKey1234567890!")),
                 ValidateIssuer = false,
                 ValidateAudience = false
             };

             var principal = tokenHandler.ValidateToken(tokenString, tokenValidationParameters, out var validatedToken);
             return null;*/
            var user = _userService.LoginUser(username, password);
            if (user == null)
            {
                return Unauthorized(user);
            }
            var token = GenerateJwtToken(user);
            return Ok(new { Token = "Bearer " + token });
        }

        private string GenerateJwtToken(User user)
        {
            /*var appSettingConfig = _config.GetSection("jwtSettings");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettingConfig["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId),  // User identifier claim (subject)
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  // Unique identifier for the token
            new Claim(ClaimTypes.Name, user.UserId),
            new Claim("RoleName", user?.UserRoles?.First()?.Roles?.RoleName),
            new Claim(ClaimTypes.Role,user.UserRoles?.First()?.RoleId.ToString())// Additional claims can be added here
            };

            // Generate the token
            var token = new JwtSecurityToken(
                //issuer: appSettingConfig["Issuer"],
                //audience: appSettingConfig["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);*/
            // Create JWT token
            /* var expirationTime = DateTime.UtcNow.AddHours(1);
             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes("b9944ede-e515-11ed-9787-0892040773d6");
             //(Configuration["Jwt:Key"]);
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim(ClaimTypes.Name, user?.UserId),
                     new Claim("UserId", user.UserId.ToString()),
                     new Claim("RoleName", user.UserRoles?.First()?.Roles?.RoleName),
                     new Claim("RoleId", user.UserRoles?.First()?.RoleId.ToString()),
                     new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expirationTime).ToUnixTimeSeconds().ToString())
                 }),
                 Expires = DateTime.UtcNow.AddHours(1),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
             };
             var token = tokenHandler.CreateToken(tokenDescriptor);
             var tokenString = tokenHandler.WriteToken(token);*/

            /* var expirationTime = DateTime.UtcNow.AddHours(1);
             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.UTF8.GetBytes("MyVerySecureSecretKey1234567890!");
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new[]
                 {
          new Claim("unique_name", "12345"),
          new Claim("UserId", "12345"),
          new Claim("RoleName", "Admin"),
          new Claim("RoleId", "1"),
           new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expirationTime).ToUnixTimeSeconds().ToString())
      }),
                 Expires = DateTime.UtcNow.AddHours(1),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
             };
             var token = tokenHandler.CreateToken(tokenDescriptor);
             string tokenString = tokenHandler.WriteToken(token);

             return tokenString;
             //return Ok(new { Token = "Bearer " + tokenString });*/
            //var expirationTime = DateTime.UtcNow.AddHours(1); // Set expiration time
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("b9944ede-e515-11ed-9787-0892040773d6");
            //(Configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user?.FirstName),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("RoleName", user.UserRoles?.First()?.Roles?.RoleName),
                    new Claim("RoleId", user.UserRoles?.First()?.RoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

       // [Authorize]

        [HttpPost("{userId}/BlockUnblockUser")]
       
        public IActionResult BlockUnblockUser(string userId)
        {
            _userService.BlockAndUnBlockUser(userId);
            return Ok("Success");

        }
    }
}
