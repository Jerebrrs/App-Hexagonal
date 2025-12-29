using App_Hexagonal.Application.tenant.ports.output;
using App_Hexagonal.Domain.tenant.model;
using App_Hexagonal.Infrastructura.data;
using App_Hexagonal.Infrastructura.tenant.persistence.entity;
using Mapster;

namespace App_Hexagonal.Infrastructura.tenant.persistence.repository;

public class TenantRepository : ITenantRepository
{
    private readonly ApplicationDbContext _context;
    public TenantRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Tenant tenant)
    {
        var tenantEnti = tenant.Adapt<TenantEntity>();

        await _context.Tenants.AddAsync(tenantEnti);
        await _context.SaveChangesAsync();
    }

    public async Task<Tenant?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Tenants.FindAsync(id);
        return entity == null ? null : new Tenant(entity.Id, entity.Name);
    }
}
