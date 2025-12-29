using App_Hexagonal.Api.tenant.Dtos.request;
using App_Hexagonal.Api.tenant.mapping;
using App_Hexagonal.Application.tenant.useCase;
using Microsoft.AspNetCore.Mvc;

namespace App_Hexagonal.Api.Controller.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {

        private readonly RegisterTenantUseCase _registerTenant;
        public TenantController(RegisterTenantUseCase registerTenant)
        {
            _registerTenant = registerTenant;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] RegisterTenantRequest request)
        {
            var tenant = await _registerTenant.ExecuteAsync(request.ToCommand());

            return CreatedAtRoute(
                routeName: "GetTenantById",
                routeValues: new { id = tenant.Id },
                value: new
                {
                    TenantId = tenant.Id,
                    Message = "Tenant Registrado correctamente"
                }
            );
        }

        [HttpGet("{id:guid}", Name = "GetTenantById")]
        public IActionResult GetById(Guid id)
        {
            return Ok(new { Id = id });
        }

    }
}
