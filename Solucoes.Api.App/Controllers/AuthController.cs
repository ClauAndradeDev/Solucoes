using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucoes.Api.Service.Cadastro;
using Solucoes.Modelo.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Solucoes.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public UsuarioService UsuarioService { get; set; }
        public AuthController(UsuarioService usuarioService)
        {
            UsuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var usuario = login?.Usuario;
            var senha = login?.Senha;

            var usuarioBanco = await UsuarioService.AcessoUsuarioLogar(usuario, senha);
            if (usuarioBanco.Codigo != 0)
            {
                var token = GenerateJwtToken(usuarioBanco);
                return Ok(new { token });
                //return Ok(new { Message = "Autorizado" });
            }
            else
            {
                return Ok("Verificar Usuário e/ou Senha incorretos!");
            }
        }


        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // O logout não requer ação especial para JWT, você pode simplesmente encerrar a sessão do lado do cliente

            return Ok("Logout bem-sucedido.");
        }

        //[HttpGet("logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    //var usuario = login?.Usuario;
        //    //var senha = login?.Senha;

        //    var result = 0;// await UsuarioService.DeslogarUsuario(usuario);
        //    if (result == 0)
        //    {
        //        return Ok(new { Message = "Desautorizado" });
        //    }
        //    else
        //    {
        //        return Ok("Verificar Usuário e/ou Senha incorretos!");
        //    }
        //}

        private string GenerateJwtToken(UsuarioDto usuario)
        {
            var token = new JwtSecurityToken();
            if (usuario != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("c2157d46fa4cb606e924ab1d1e0e1d5b868adf9a8d690fd41820fa8433e475b4"));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Login),
                    new Claim(ClaimTypes.Email, usuario.Pessoa.Email),
                    // Adicione outras reivindicações personalizadas conforme necessário
                };

                token = new JwtSecurityToken(
                    "solucoes_issuer",
                    "solucoes_audience",
                    claims,
                    expires: DateTime.Now.AddHours(168), // Defina o tempo de expiração do token
                    signingCredentials: credentials
                );

                
            }
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
