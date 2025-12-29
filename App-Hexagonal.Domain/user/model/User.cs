using App_Hexagonal.Domain.Common;

namespace App_Hexagonal.Domain.user.model;

public class User : BaseEntity<Guid>
{
    public Guid TenantId { get; private set; }
    public string Email { get; set; }
    public string UserName { get; set; }

    public User(Guid id, Guid tenantId, string email, string userName) : base(id)
    {
        this.TenantId = tenantId;
        this.Email = email;
        this.UserName = userName;
    }
}
