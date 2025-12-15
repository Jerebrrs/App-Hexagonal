using System;

namespace App_Hexagonal.Domain.Contracts.Entities;

public class Contract
{
    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid PropertyId { get; }

    public Contract(Guid id, Guid userId, Guid propertyId)
    {
        Id = id;
        UserId = userId;
        PropertyId = propertyId;
    }
}
