using System;
using App_Hexagonal.Domain.contracts.Base;
using App_Hexagonal.Domain.contracts.valueObjects;

namespace App_Hexagonal.Domain.contracts.Lease;

public class LeaseContract : Contract
{
    public Guid LandlordId { get; private set; }

    public int DurationMonths { get; private set; }

    public decimal InitialAmount { get; private set; }
    public Currency Currency { get; private set; }

    public UpdatePeriodicity Periodicity { get; private set; }
    public UpdateIndex Index { get; private set; }
    public bool AutoRenew { get; private set; }

    public List<string> CustomClauses { get; private set; } = new();

    public LeaseContract()
    {
    }

    public LeaseContract(Guid id, Guid tenantId, Guid landlordId, Guid propertyId, int durationMonths, DateTime startDate, decimal monthlyAmount, Currency currency, UpdateIndex updateIndex, UpdatePeriodicity updatePeriodicity, bool autoRenew = false, List<string>? customClauses = null) : base(id, tenantId, propertyId, startDate, monthlyAmount)
    {
        if (durationMonths <= 0) throw new ArgumentException("La duración debe ser mayor a 0 meses");

        LandlordId = landlordId;
        DurationMonths = durationMonths;
        Currency = currency;
        Periodicity = updatePeriodicity;
        Index = updateIndex;
        AutoRenew = autoRenew;

        if (customClauses != null) CustomClauses = customClauses;
    }
    public void Extend(int additionalMonths)
    {
        if (additionalMonths <= 0) throw new ArgumentException("Meses adicionales deben ser mayores a cero");

        EndDate = EndDate!.Value.AddMonths(additionalMonths);

    }

    public void AddClause(string clause)
    {
        if (string.IsNullOrWhiteSpace(clause))
            throw new ArgumentException("La cláusula no puede estar vacía");

        CustomClauses.Add(clause);
    }

    public void RemoveClause(string clause)
    {
        CustomClauses.Remove(clause);
    }
}
