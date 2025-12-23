using System;
using App_Hexagonal.Domain.user.model;

namespace App_Hexagonal.Application.user.ports.output;

public interface IUserRepository
{
    Task AddAsync(User user);
}
