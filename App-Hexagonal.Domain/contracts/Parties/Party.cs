using System;
using App_Hexagonal.Domain.Common;

namespace App_Hexagonal.Domain.contracts.Parties;

public class Party : BaseEntity<Guid>
{
    public string Name { get; protected set; } = default!;
    public string Document { get; protected set; } = default!; // DNI o CUIT
    public string? Address { get; protected set; }
    public string? Email { get; protected set; }
    public string? Phone { get; protected set; }
    public PartyType Type { get; protected set; }
    protected Party()
    {
    }

    protected Party(Guid id, Guid tenantId, string name, string document, PartyType type, string? address = null, string? email = null, string? phone = null) : base(id, tenantId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre es obligatorio");

        if (string.IsNullOrWhiteSpace(document))
            throw new ArgumentException("El documento es obligatorio");

        Name = name;
        Document = document;
        Type = type;
        Address = address;
        Email = email;
        Phone = phone;
    }

    public void UpdateContactInfo(string? email, string? phone, string? address)
    {
        if (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
            throw new ArgumentException("Email inválido");

        Email = email;
        Phone = phone;
        Address = address;
    }

    public void ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("El nombre no puede estar vacío");

        Name = newName;
    }
}
