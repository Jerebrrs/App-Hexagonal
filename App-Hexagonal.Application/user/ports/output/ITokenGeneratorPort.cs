using System;

namespace App_Hexagonal.Application.user.ports.output;

public interface ITokenGeneratorPort
{
    string GenerateToken(UserAuthInfo user);
}
