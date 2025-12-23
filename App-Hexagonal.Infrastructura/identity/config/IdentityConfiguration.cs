using System;
using App_Hexagonal.Infrastructura.data;
using App_Hexagonal.Infrastructura.identity.entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace App_Hexagonal.Infrastructura.identity.config;

public static class IdentityConfiguration
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
    {
        services
            .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
