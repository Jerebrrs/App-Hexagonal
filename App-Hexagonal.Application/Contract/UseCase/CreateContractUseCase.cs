
using App_Hexagonal.Application.Contract.Ports.In;
using App_Hexagonal.Application.Contract.Ports.Out;

namespace App_Hexagonal.Application.Contracts.UseCase
{
    public class CreateContractUseCase : ICreateContractUseCase
    {
        private readonly IContractRepository _repository;
        public CreateContractUseCase(IContractRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Execute(Guid userId, Guid propertyId)
        {
            var contract = new Domain.Contracts.Entities.Contract(Guid.NewGuid(), userId, propertyId);
            await _repository.Save(contract);
            return contract.Id;
        }
    }
}