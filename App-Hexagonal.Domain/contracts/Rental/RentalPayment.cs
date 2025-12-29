using System;
using App_Hexagonal.Domain.Common;

namespace App_Hexagonal.Domain.contracts.Rental;

public class RentalPayment : BaseEntity<Guid>
{
    public Guid LeaseContractId { get; private set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }

    public bool Paid { get; private set; }

    public void MarkAsPaid() => Paid = true;

}
