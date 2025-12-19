
namespace App_Hexagonal.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        protected BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }
        protected BaseEntity(Guid id)
        {
            this.Id = id;
        }
    }
}