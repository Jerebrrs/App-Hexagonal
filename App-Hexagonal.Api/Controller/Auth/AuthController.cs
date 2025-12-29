using App_Hexagonal.Application.user.useCase;
using App_Hexagonal.Application.user.useCase.command;
using Microsoft.AspNetCore.Mvc;

namespace App_Hexagonal.Api.Controller.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginUserUseCase _login;
        public AuthController(LoginUserUseCase login)
        {
            _login = login;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await _login.ExecuteAsync(command);
            return Ok(result);
        }
    }
}
