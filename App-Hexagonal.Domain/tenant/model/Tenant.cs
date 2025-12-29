namespace App_Hexagonal.Domain.tenant.model
{
    public class Tenant
    {
        public Guid TenantId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        public Tenant() { }
        public Tenant(Guid id, string name)
        {
            this.TenantId = id;
            this.Name = name;
            this.IsActive = true;

        }
        public void Deactive()
        {
            this.IsActive = false;
        }
    }
}