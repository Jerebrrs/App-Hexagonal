using System;

namespace App_Hexagonal.Infrastructura.tenant.ports.output;

public interface IAuthUserPort
{
    Task<Guid> CreateAdminUserAsync(Guid tenantId, string email, string userName, string password);

}
