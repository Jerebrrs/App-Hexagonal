using System;
using App_Hexagonal.Api.tenant.Dtos.request;
using App_Hexagonal.Application.tenant.useCase.command;

namespace App_Hexagonal.Api.tenant.mapping;

public static class TenantRestMapping
{
    public static RegisterTenantCommand ToCommand(
            this RegisterTenantRequest request)
            => new(
                request.TenantName,
                request.AdminEmail,
                request.AdminUserName,
                request.Password
            );
}
