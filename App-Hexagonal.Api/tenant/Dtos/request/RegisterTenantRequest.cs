using System;

namespace App_Hexagonal.Api.tenant.Dtos.request;

public class RegisterTenantRequest
{
    public string TenantName { get; set; } = null!;

    // Admin inicial
    public string AdminEmail { get; set; } = null!;
    public string AdminUserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
