using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using PracticalTest.Core.Repositories;
using PracticalTest.Core.Repositories.Client;
using PracticalTest.Core.Repositories.Invoice;
using PracticalTest.Core.Repositories.Loan;
using PracticalTest.Repository.Repositories.Client;
using PracticalTest.Repository.Repositories.Invoice;
using PracticalTest.Repository.Repositories.Loan;

namespace PracticalTest.Repository
{
    public class UniteOfWork:IUniteOfWork,IDisposable
    {
        private  readonly LoanDbContext _context;

        public UniteOfWork(LoanDbContext context)
        {
            _context = context;
        }

        public IClientRepository ClientRepository => new ClientRepository(_context);

        public ILoanRepository LoanRepository => new LoanRepository(_context);
        public IInvoiceRepository InvoiceRepository => new InvoiceRepository(_context);


        public async Task<int> SaveAsync()
        {
          return await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}