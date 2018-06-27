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
        private readonly P2HelpContext _context;

        public TokenController(IConfiguration configuration, P2HelpContext context)
        {
            // injeta o configuration para pegar a chave definida me appsetings
            _configuration = configuration;
            // injeta o context para conseguir acessar a model usuario e verificar usuario e senha
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Usuario request)
        {
            // se any retornar true, filtrando por usuario e senha passados 
            if(_context.Usuario.Any(e => (e.Login == request.Login) && (e.Pass == request.Pass))) //request.Login == "1" && request.Pass == "1")
            {
                Usuario usuario = _context.Usuario
                    .Where(e => e.Login == request.Login )
                    .FirstOrDefault();
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, usuario.PerfilAcesso)
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
