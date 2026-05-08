using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Vidrotec.Application.DTOs;

namespace Vidrotec.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponseDto> Login([FromBody] LoginRequestDto request)
        {
            if (request.Username != "admin" || request.Password != "password")
            {
                return Unauthorized(new { error = "Credenciais inválidas." });
            }

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? string.Empty));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiresMinutes"] ?? "120"));

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, request.Username) },
                expires: expires,
                signingCredentials: creds);

            return Ok(new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = expires.ToString("o")
            });
        }
    }
}
