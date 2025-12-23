using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.user.ports.output;
using App_Hexagonal.Application.user.useCase.command;
using App_Hexagonal.Domain.user.model;

namespace App_Hexagonal.Application.user.useCase;

public class CreateUserUseCase : IUseCase<CreateUserCommand, User>
{
    private readonly IUserRepository _repository;
    public CreateUserUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> ExecuteAsync(CreateUserCommand request)
    {
        var user = new User(Guid.NewGuid(), request.TenantId, request.email, request.userName);
        await _repository.AddAsync(user);
        return user;
    }
}
