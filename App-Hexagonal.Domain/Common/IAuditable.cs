namespace App_Hexagonal.Domain.Common;

public interface IAuditable
{
    DateTime? CreatedAt { get; }
    DateTime? UpdatedAt { get; }
    DateTime? DeletedAt { get; }
    void MarkCreated();
    void MarkUpdated();
    void MarkDeleted();
}
