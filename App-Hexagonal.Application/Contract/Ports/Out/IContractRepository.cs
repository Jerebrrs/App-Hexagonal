using App_Hexagonal.Domain.Contracts.Entities;
using ContractEntity = App_Hexagonal.Domain.Contracts.Entities.Contract;

namespace App_Hexagonal.Application.Contract.Ports.Out;

public interface IContractRepository
{
    Task Save(ContractEntity contract);
}
