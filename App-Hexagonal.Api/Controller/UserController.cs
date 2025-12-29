using App_Hexagonal.Api.user.Dtos.request;
using App_Hexagonal.Application.Common.security;
using App_Hexagonal.Application.user.useCase;
using App_Hexagonal.Application.user.useCase.command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_Hexagonal.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CreateUserUseCase _createUser;
        private readonly TenantCreateUserUseCase _tenantCreateUser;
        public UserController(CreateUserUseCase createUser, TenantCreateUserUseCase tenantCreateUser)
        {
            _createUser = createUser;
            _tenantCreateUser = tenantCreateUser;
        }
        [HttpPost]
        // [Authorize(Policy = Policies.TenantAdmin)]

        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var user = await _createUser.ExecuteAsync(new CreateUserCommand(request.Email, request.UserName, request.Password));
            return Ok(user);
        }

        [HttpGet("test-empty")]
        // [Authorize(Policy = Policies.TenantAdmin)]
        public IActionResult GetEmpty()
        {
            return Ok(new string[] { });
        }
        [HttpGet("debug-auth")]
        [Authorize(Policy = Policies.TenantAdmin)]
        public IActionResult DebugAuth()
        {
            return Ok(new
            {
                IsAuthenticated = User.Identity?.IsAuthenticated,
                Claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }

        [HttpPost("tenant-create")]
        // [Authorize(Policy = Policies.TenantAdmin)]
        public async Task<IActionResult> TenantCreate([FromBody] TenantCreateUserRequest request)
        {
            var user = await _tenantCreateUser.ExecuteAsync(
                new TenantCreateUserCommand(request.Email, request.UserName, request.Password, request.Role)
            );
            return Ok(user);
        }
    }
}
