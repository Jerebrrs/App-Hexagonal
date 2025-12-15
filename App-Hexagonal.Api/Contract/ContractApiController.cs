using App_Hexagonal.Application.Contracts.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace App_Hexagonal.Api.Contract
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractApiController : ControllerBase
    {
        private readonly ICreateContractUseCase _useCase;

        public ContractApiController(ICreateContractUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContractRequest request)
        {
            var id = await _useCase.Execute(request.UserId, request.PropertyId);
            return Ok(id);
        }

    }
}