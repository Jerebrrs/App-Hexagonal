using App_Hexagonal.Application.Contracts.Ports.Out;


namespace App_Hexagonal.Infrastructura.Contract
{
    public class InMemoryContractRepository : IContractRepository
    {
        private static readonly List<Domain.Contracts.Entities.Contract> _contracts = new();
        public Task Save(Domain.Contracts.Entities.Contract contract)
        {
            _contracts.Add(contract);
            return Task.CompletedTask;
        }
    }
}