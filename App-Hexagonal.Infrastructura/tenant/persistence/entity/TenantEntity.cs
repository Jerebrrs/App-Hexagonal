using System;
using App_Hexagonal.Infrastructura.identity.entity;

namespace App_Hexagonal.Infrastructura.tenant.persistence.entity;

public class TenantEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }

    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}
