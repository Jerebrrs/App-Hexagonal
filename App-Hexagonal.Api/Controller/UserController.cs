using App_Hexagonal.Api.user.Dtos.request;
using App_Hexagonal.Application.user.useCase;
using App_Hexagonal.Application.user.useCase.command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_Hexagonal.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CreateUserUseCase _createUser;
        public UserController(CreateUserUseCase createUser)
        {
            _createUser = createUser;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var user = await _createUser.ExecuteAsync(new CreateUserCommand(request.TenantId, request.Email, request.UserName, request.Password));
            return Ok(user);
        }
    }
}
