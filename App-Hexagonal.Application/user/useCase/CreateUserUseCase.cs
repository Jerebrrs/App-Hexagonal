using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.user.ports.output;
using App_Hexagonal.Application.user.useCase.command;
using App_Hexagonal.Domain.user.model;

namespace App_Hexagonal.Application.user.useCase;

public class CreateUserUseCase : IUseCase<CreateUserCommand, User>
{
    private readonly IUserIdentityPort _repository;
    public CreateUserUseCase(IUserIdentityPort repository)
    {
        _repository = repository;
    }

    public async Task<User> ExecuteAsync(CreateUserCommand request)
    {
        var userId = await _repository.CreateAsync(
            request.TenantId,
            request.email,
            request.userName,
            request.password
        );
        return new User(
                    userId,
                    request.TenantId,
                    request.email,
                    request.userName
                );
    }
}
