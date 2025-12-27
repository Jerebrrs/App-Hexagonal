using System;

namespace App_Hexagonal.Api.user.Dtos.request;

public class CreateUserRequest
{
    public Guid TenantId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
