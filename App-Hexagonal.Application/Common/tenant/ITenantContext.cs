namespace App_Hexagonal.Application.Common.tenant;

public interface ITenantContext
{
    Guid TenantId { get; }
    bool HasTenant { get; }
}
