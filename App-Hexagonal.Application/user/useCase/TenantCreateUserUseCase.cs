using App_Hexagonal.Application.Common.tenant;
using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.user.ports.output;
using App_Hexagonal.Application.user.useCase.command;
using App_Hexagonal.Domain.user.model;

namespace App_Hexagonal.Application.user.useCase;

public class TenantCreateUserUseCase : IUseCase<TenantCreateUserCommand, User>
{
    private readonly ITenantContext _tenantContext;
    private readonly IUserIdentityPort _repository;
    public TenantCreateUserUseCase(ITenantContext tenantContext, IUserIdentityPort repository)
    {
        _tenantContext = tenantContext;
        _repository = repository;
    }

    public async Task<User> ExecuteAsync(TenantCreateUserCommand request)
    {
        var tenantId = _tenantContext.TenantId;
        if (!_tenantContext.HasTenant)
        {
            throw new Exception("Tenant no válido o inexistente");
        }
        var userId = await _repository.CreateAsync(
            tenantId,
            request.Email,
            request.UserName,
            request.Password,
            roles: request.Role
        );
        return new User(
            userId,
            tenantId,
            request.Email,
            request.UserName
        );
    }
}
