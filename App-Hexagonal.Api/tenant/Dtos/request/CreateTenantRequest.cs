using System;

namespace App_Hexagonal.Api.tenant.Dtos.request;

public class CreateTenantRequest
{
    public string Name { get; set; } = null!;
}
