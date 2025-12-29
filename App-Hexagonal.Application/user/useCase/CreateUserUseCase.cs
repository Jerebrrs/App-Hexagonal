using App_Hexagonal.Application.Common.security;
using App_Hexagonal.Application.Common.tenant;
using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.user.ports.output;
using App_Hexagonal.Application.user.useCase.command;
using App_Hexagonal.Domain.user.model;

namespace App_Hexagonal.Application.user.useCase;

public class CreateUserUseCase : IUseCase<CreateUserCommand, User>
{
    private readonly ITenantContext _tenantContext;
    private readonly IUserIdentityPort _repository;
    public CreateUserUseCase(ITenantContext tenantContext, IUserIdentityPort repository)
    {
        _tenantContext = tenantContext;
        _repository = repository;
    }

    public async Task<User> ExecuteAsync(CreateUserCommand request)
    {
        var tenantId = _tenantContext.TenantId;

        if (!_tenantContext.HasTenant)
        {
            throw new Exception("Tenant no válido o inexistente");
        }


        var userId = await _repository.CreateAsync(
            tenantId,
            request.email,
            request.userName,
            request.password, roles: Roles.Admin
        );
        return new User(
                    userId,
                    tenantId,
                    request.email,
                    request.userName
                );
    }
}
