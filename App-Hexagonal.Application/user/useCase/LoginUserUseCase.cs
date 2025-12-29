using System;
using App_Hexagonal.Application.auth.useCase.result;
using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.user.ports.output;
using App_Hexagonal.Application.user.useCase.command;

namespace App_Hexagonal.Application.user.useCase;

public class LoginUserUseCase : IUseCase<LoginUserCommand, LoginResult>
{
    private readonly IUserIdentityPort _userIdentity;
    private readonly IAuthTokenPort _tokenPort;
    public LoginUserUseCase(IUserIdentityPort userIdentity, IAuthTokenPort tokenPort)
    {
        _userIdentity = userIdentity;
        _tokenPort = tokenPort;
    }
    public async Task<LoginResult> ExecuteAsync(LoginUserCommand request)
    {
        var user = await _userIdentity.ValidateCredentialsAsync(request.Email, request.Password);
        if (user is null) throw new UnauthorizedAccessException("Credenciales inválidas");

        var token = _tokenPort.GenerateToken(
            user.UserId,
            user.TenantId,
            user.Email,
            user.Roles
        );
        return new LoginResult(
            user.UserId,
            user.TenantId,
            user.Email,
            user.Roles,
            token
        );

    }
}
