using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticalTest.Core.Repositories.Invoice
{
    public interface IInvoiceRepository:IRepository<Entities.Invoice>
    {
        Task<IEnumerable<Entities.Invoice>> GetInvoiceListByLoanDataProcAsync(Entities.Loan loan);
    }
}