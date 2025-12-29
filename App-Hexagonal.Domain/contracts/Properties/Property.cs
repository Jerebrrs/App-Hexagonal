using System;
using App_Hexagonal.Domain.Common;

namespace App_Hexagonal.Domain.contracts.Properties;

public class Property : BaseEntity<Guid>
{
    public string Address { get; private set; } = string.Empty;
    public PropertyType Type { get; private set; }
    public decimal Area { get; private set; }
    public int Rooms { get; private set; }
    public int Bathrooms { get; private set; }
    public string? Description { get; private set; }

    protected Property() { }

    protected Property(Guid id, Guid tenantId, string address, PropertyType type, decimal area, int rooms, int bathrooms, string? description = null) : base(id, tenantId)
    {
        this.Address = address ?? throw new ArgumentNullException(nameof(address));
        Type = type;
        this.Type = type;
        this.Rooms = rooms;
        this.Bathrooms = bathrooms;
        this.Description = description;
    }

    public void UpdateDetails(string address, PropertyType type, decimal area, int rooms, int bathrooms, string? description = null)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Type = type;
        Area = area;
        Rooms = rooms;
        Bathrooms = bathrooms;
        Description = description;
        MarkUpdated();
    }


}
