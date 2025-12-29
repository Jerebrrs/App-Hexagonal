
namespace App_Hexagonal.Domain.Common
{
    public class BaseEntity<TId> : IAuditable
    {
        public TId Id { get; protected set; } = default!;

        public DateTime? CreatedAt { get; protected set; }

        public DateTime? UpdatedAt { get; protected set; }

        public DateTime? DeletedAt { get; protected set; }

        protected BaseEntity() { }
        protected BaseEntity(TId id)
        {
            Id = id;
            MarkCreated();
        }

        public void MarkCreated()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkDeleted()
        {
            DeletedAt = DateTime.UtcNow;
        }
    }
}