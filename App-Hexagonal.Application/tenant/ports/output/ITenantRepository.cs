using App_Hexagonal.Domain.tenant.model;

namespace App_Hexagonal.Application.tenant.ports.output
{
    public interface ITenantRepository
    {
        Task<Tenant?> GetByIdAsync(Guid id);
        Task AddAsync(Tenant tenant);
    }
}