using System;
using App_Hexagonal.Application.Common.tenant;
using App_Hexagonal.Application.student.useCase;
using App_Hexagonal.Application.tenant.useCase;
using App_Hexagonal.Application.user.useCase;
using Microsoft.Extensions.DependencyInjection;


namespace App_Hexagonal.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<HttpTenantContext>();
        // Students
        services.AddScoped<CreateStudentUseCase>();
        services.AddScoped<GetAllStudentsUseCase>();
        services.AddScoped<GetStudentByIdUseCase>();
        services.AddScoped<UpdateStudentUseCase>();
        services.AddScoped<DeleteStudentUseCase>();

        services.AddScoped<CreateTenantUseCase>();


        services.AddScoped<CreateUserUseCase>();

        services.AddScoped<RegisterTenantUseCase>();
        services.AddScoped<LoginUserUseCase>();

        // Contracts (ejemplo)
        // services.AddScoped<CreateContractUseCase>();
        // ...

        return services;
    }
}
