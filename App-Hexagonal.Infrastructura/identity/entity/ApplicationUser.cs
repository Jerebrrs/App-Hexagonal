using System;
using App_Hexagonal.Infrastructura.tenant.persistence.entity;
using Microsoft.AspNetCore.Identity;

namespace App_Hexagonal.Infrastructura.identity.entity;

public class ApplicationUser : IdentityUser<Guid>
{
    public Guid TenantId { get; set; }
    public TenantEntity? Tenant { get; private set; }

    public ApplicationUser() { }
    public ApplicationUser(Guid tenantId, string email, string userName)
    {
        Id = Guid.NewGuid();
        TenantId = tenantId;
        Email = email;
        UserName = userName;
    }
}
