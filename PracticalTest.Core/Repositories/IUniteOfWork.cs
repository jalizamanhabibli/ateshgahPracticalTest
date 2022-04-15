using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using PracticalTest.Core.Repositories.Client;
using PracticalTest.Core.Repositories.Invoice;
using PracticalTest.Core.Repositories.Loan;

namespace PracticalTest.Core.Repositories
{
    public interface IUniteOfWork
    {
        public IClientRepository ClientRepository { get; }
        public ILoanRepository LoanRepository { get;  }
        public IInvoiceRepository InvoiceRepository { get; }
        Task<int> SaveAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}