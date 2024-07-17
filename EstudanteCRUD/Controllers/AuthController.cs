using EstudanteCRUD.Models;
using EstudanteCRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstudanteCRUD.Controllers
{
    [ApiController]
    [Route("api/auth/login")]
    public class AuthController : Controller
    {
        /// <summary>
        ///  Autentica um usuário e retorna um token JWT.
        /// </summary>
        /// <remarks>
        /// Username (nome de usuário) : ubc. 
        /// Password (senha) : 123
        /// </remarks>
        /// <param name="username">Nome de usuário</param>
        /// <param name="password">Senha</param>
        /// <returns></returns>
        /// <response code="200">Usuário autenticado com sucesso.</response>
        /// <response code="400">Erro de validação.</response>
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "ubc" && password == "123")
            {
                var token = TokenService.GenerateToken(new Student());
                return Ok(token);
            }

            return BadRequest("Login ou senha inválidos.");
        }
    }
}
