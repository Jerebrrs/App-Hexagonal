using System;
using App_Hexagonal.Application.student.useCase;
using Microsoft.Extensions.DependencyInjection;


namespace App_Hexagonal.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Students
        services.AddScoped<CreateStudentUseCase>();
        services.AddScoped<GetAllStudentsUseCase>();
        services.AddScoped<GetStudentByIdUseCase>();
        services.AddScoped<UpdateStudentUseCase>();
        services.AddScoped<DeleteStudentUseCase>();

        // Contracts (ejemplo)
        // services.AddScoped<CreateContractUseCase>();
        // ...

        return services;
    }
}
