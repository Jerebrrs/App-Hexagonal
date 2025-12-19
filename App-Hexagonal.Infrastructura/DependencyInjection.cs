using System;
using App_Hexagonal.Application.student.ports;
using App_Hexagonal.Infrastructura.student.persistence.repository;
using Microsoft.Extensions.DependencyInjection;

namespace App_Hexagonal.Infrastructura;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IStudentPersistePort, StudentRepository>();

        return services;
    }
}
