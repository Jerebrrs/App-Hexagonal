using App_Hexagonal.Application.Common.security;
using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.tenant.ports.output;
using App_Hexagonal.Application.tenant.useCase.command;
using App_Hexagonal.Application.user.ports.output;
using App_Hexagonal.Domain.tenant.model;

namespace App_Hexagonal.Application.tenant.useCase;

public class RegisterTenantUseCase : IUseCase<RegisterTenantCommand, Tenant>
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IUserIdentityPort _userRepository;

    public RegisterTenantUseCase(ITenantRepository tenantRepository, IUserIdentityPort userIdentityPort)
    {
        _tenantRepository = tenantRepository;
        _userRepository = userIdentityPort;
    }
    public async Task<Tenant> ExecuteAsync(RegisterTenantCommand request)
    {
        var tenant = new Tenant(Guid.NewGuid(), request.TenantName);
        await _tenantRepository.AddAsync(tenant);

        await _userRepository.CreateAsync(tenant.Id, request.AdminEmail, request.AdminUserName, request.Password, roles: Roles.Admin);

        return tenant;
    }
}
