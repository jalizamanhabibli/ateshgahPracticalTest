using PracticalTest.Core.Repositories.Client;

namespace PracticalTest.Repository.Repositories.Client
{
    public class ClientRepository:Repository<Core.Entities.Client>,IClientRepository
    {
        public ClientRepository(LoanDbContext context) : base(context)
        {
        }
    }
}