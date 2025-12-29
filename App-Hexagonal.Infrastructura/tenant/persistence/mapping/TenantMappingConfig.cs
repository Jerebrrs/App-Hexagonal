using App_Hexagonal.Domain.tenant.model;
using App_Hexagonal.Infrastructura.tenant.persistence.entity;
using Mapster;

namespace App_Hexagonal.Infrastructura.tenant.persistence.mapping;

public static class TenantMappingConfig
{
    public static void Register()
    {
        TypeAdapterConfig<TenantEntity, Tenant>.NewConfig();
        TypeAdapterConfig<Tenant, TenantEntity>
     .NewConfig()
     .Ignore(dest => dest.Users);

    }

}
