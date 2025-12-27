using System;

namespace App_Hexagonal.Application.user.ports.output;

public interface IAuthTokenPort
{
    string GenerateToken(
          Guid userId,
        Guid tenantId,
        string email,
        IReadOnlyList<string> roles
    );
}
