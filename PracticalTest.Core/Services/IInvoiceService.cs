using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalTest.Core.Dtos;

namespace PracticalTest.Core.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoicesTableDto>> GetInvoiceListByLoanDataProcAsync(CalculateLoanDto calculateLoanDto);
    }
}