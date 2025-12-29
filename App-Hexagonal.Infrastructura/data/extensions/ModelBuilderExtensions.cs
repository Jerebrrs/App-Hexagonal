using System;
using System.Linq.Expressions;
using App_Hexagonal.Application.Common.tenant;
using App_Hexagonal.Infrastructura.Commont;
using Microsoft.EntityFrameworkCore;

namespace App_Hexagonal.Infrastructura.data.extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyTenantFilter(this ModelBuilder modelBuilder, ITenantContext tenantContext)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(ITenantEntity).IsAssignableFrom(entityType.ClrType))
                continue;

            var parameter = Expression.Parameter(entityType.ClrType, "e");
            var property = Expression.Property(parameter, nameof(ITenantEntity.TenantId));
            var tenantId = Expression.Constant(tenantContext.TenantId);

            var body = Expression.Equal(property, tenantId);
            var lambda = Expression.Lambda(body, parameter);

            modelBuilder.Entity(entityType.ClrType)
                .HasQueryFilter(lambda);
        }
    }
}
