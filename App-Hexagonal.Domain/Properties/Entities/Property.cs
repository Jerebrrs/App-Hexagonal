using System;

namespace App_Hexagonal.Domain.Properties.Entities;

public class Property
{
    public Guid Id { get; }
    public string Address { get; }

    public Property(Guid id, string address)
    {
        Id = id;
        Address = address;
    }
}
