namespace App_Hexagonal.Application.auth.useCase.result;

public record class LoginResult(Guid UserId, Guid TenantId, string Email, IReadOnlyList<string> Roles, string AccessToken);
