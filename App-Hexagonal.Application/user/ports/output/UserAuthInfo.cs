namespace App_Hexagonal.Application.user.ports.output;

public record class UserAuthInfo(
    Guid UserId,
    Guid TenantId,
    string Email,
    IReadOnlyList<string> Roles
    );
