namespace App_Hexagonal.Application.Contract.Ports.In;

public interface ICreateContractUseCase
{
    Task<Guid> Execute(Guid userId, Guid propertyId);
}
