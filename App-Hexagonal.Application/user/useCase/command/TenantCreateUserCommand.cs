using System;

namespace App_Hexagonal.Application.user.useCase.command;

public record TenantCreateUserCommand(string Email, string UserName, string Password, string Role);
