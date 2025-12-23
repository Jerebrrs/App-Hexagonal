using App_Hexagonal.Domain.Common;

namespace App_Hexagonal.Domain.tenant.model
{
    public class Tenant : BaseEntity<Guid>
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public Tenant(Guid id, string name) : base(id)
        {
            this.Name = name;
            this.IsActive = true;
        }

        public void Deactive()
        {
            this.IsActive = false;
            MarkUpdated();
        }
    }
}