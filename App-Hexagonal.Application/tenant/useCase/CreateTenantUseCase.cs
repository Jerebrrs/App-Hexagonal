using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.tenant.ports.output;
using App_Hexagonal.Application.tenant.useCase.command;
using App_Hexagonal.Domain.tenant.model;

namespace App_Hexagonal.Application.tenant.useCase;

public class CreateTenantUseCase : IUseCase<CreateTenantCommand, Tenant>
{
    private readonly ITenantRepository _repository;
    public CreateTenantUseCase(ITenantRepository repository)
    {
        _repository = repository;
    }

    public async Task<Tenant> ExecuteAsync(CreateTenantCommand request)
    {
        var tenant = new Tenant(Guid.NewGuid(), request.name);
        await _repository.AddAsync(tenant);
        return tenant;
    }
}