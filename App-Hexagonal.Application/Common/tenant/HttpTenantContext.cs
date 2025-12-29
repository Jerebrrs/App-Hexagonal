

namespace App_Hexagonal.Application.Common.tenant;

public class HttpTenantContext : ITenantContext
{

    public Guid TenantId { get; private set; }

    public bool HasTenant => TenantId != Guid.Empty;

    public void SetTenant(Guid tenantId)
    {
        this.TenantId = tenantId;
    }
}
