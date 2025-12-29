using App_Hexagonal.Domain.Common;

namespace App_Hexagonal.Domain.contracts.Base;

public abstract class Contract : BaseEntity<Guid>
{
    public Guid PropertyId { get; private set; }

    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; protected set; }

    public decimal MonthlyAmount { get; private set; }
    public ContractStatus Status { get; private set; }
    protected Contract()
    {
    }

    protected Contract(Guid id, Guid tenantId, Guid propertyId, DateTime startDate, decimal monthlyAmount) : base(id, tenantId)
    {
        if (monthlyAmount <= 0)
            throw new ArgumentException("El monto mensual debe ser mayor a cero");

        PropertyId = propertyId;
        StartDate = startDate;
        MonthlyAmount = monthlyAmount;
        Status = ContractStatus.Draft;
    }

    public void Activate()
    {
        if (Status != ContractStatus.Draft)
            throw new InvalidOperationException("Solo un contrato o en borrador puede activarse");
    }


    public void Finished(DateTime finishDate)
    {
        if (Status != ContractStatus.Active) throw new InvalidOperationException("Solo un contrato activo puede finalizarse");
        if (finishDate < StartDate) throw new InvalidOperationException("La fecha de finalizacion no puede ser anterior al inicio");

        EndDate = finishDate;
        Status = ContractStatus.Finished;
    }

    public void Cancel(string reason)
    {
        if (Status == ContractStatus.Finished) throw new InvalidOperationException("Un contrato finalizado no puede cancelarse");
        Status = ContractStatus.Cancelled;
    }
}
