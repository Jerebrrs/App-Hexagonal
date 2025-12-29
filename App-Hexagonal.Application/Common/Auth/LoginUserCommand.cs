using System;

namespace App_Hexagonal.Application.Common.Auth;

public record LoginUserCommand(string Email, string Password);
