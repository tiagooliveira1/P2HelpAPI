using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using P2HelpAPICore.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace P2HelpAPICore.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            // injeta o configuration para pegar a chave definida me appsetings
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Usuario request)
        {
            if(request.Login == "1" && request.Pass == "1")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "Tiago"),
                    new Claim(ClaimTypes.Role, "usuario_normal")
                };

                // recebe uma instancia de SymmetricSecurityKey 
                // gerando a chave criptográfica 
                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // gera o token efetivamente
                var token = new JwtSecurityToken(
                    issuer: "P2Help",
                    audience: "P2Help",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Credenciais inválidas");
        }
    }
}
