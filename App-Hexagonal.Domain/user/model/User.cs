using App_Hexagonal.Domain.Common;
using App_Hexagonal.Domain.contracts.Parties;

namespace App_Hexagonal.Domain.user.model;

public class User : BaseEntity<Guid>
{
    public string Email { get; private set; } = string.Empty;
    public string UserName { get; private set; } = string.Empty;

    public Guid? PartyId { get; private set; }
    public Party? Party { get; private set; }

    protected User() { }

    public User(Guid id, Guid tenantId, string email, string userName, Party? party = null) : base(id, tenantId)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email es obligatorio", nameof(email));
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("UserName es obligatorio", nameof(userName));

        Email = email;
        UserName = userName;

        if (party != null) SetParty(party);

    }

    public void SetParty(Party party)
    {
        Party = party ?? throw new ArgumentNullException(nameof(party));
        PartyId = party.Id;
    }
    public void UpdateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email no puede estar vacío", nameof(email));

        Email = email;
    }

    public void UpdateUserName(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("UserName no puede estar vacío", nameof(userName));

        UserName = userName;
    }

}
