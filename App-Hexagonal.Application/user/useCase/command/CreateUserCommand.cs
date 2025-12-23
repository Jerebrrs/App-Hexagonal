using System;

namespace App_Hexagonal.Application.user.useCase.command;

public record CreateUserCommand(Guid TenantId, string email, string userName, string password);
