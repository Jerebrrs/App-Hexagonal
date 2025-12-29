using App_Hexagonal.Application.Common.tenant;
using App_Hexagonal.Application.student.ports;
using App_Hexagonal.Application.tenant.ports.output;
using App_Hexagonal.Application.user.ports.output;
using App_Hexagonal.Infrastructura.auth.adapter;
using App_Hexagonal.Infrastructura.identity.adapter;
using App_Hexagonal.Infrastructura.student.persistence.repository;
using App_Hexagonal.Infrastructura.tenant.persistence.repository;
using App_Hexagonal.Infrastructura.tenant.ports.output;
using Microsoft.Extensions.DependencyInjection;

namespace App_Hexagonal.Infrastructura;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITenantContext, HttpTenantContext>();
        services.AddScoped<IStudentPersistePort, StudentRepository>();
        services.AddScoped<IUserIdentityPort, IdentityUserAdapter>();
        services.AddScoped<ITenantRepository, TenantRepository>();

        services.AddScoped<IAuthUserPort, IdentityAuthUserAdapter>();

        services.AddScoped<IAuthTokenPort, JwtTokenAdapter>();


        return services;
    }
}
