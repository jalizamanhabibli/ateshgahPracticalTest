using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Core.Repositories;
using PracticalTest.Core.Repositories.Loan;

namespace PracticalTest.Repository.Repositories.Loan
{
    public class LoanRepository:Repository<Core.Entities.Loan>,ILoanRepository
    {
        public LoanRepository(LoanDbContext context) : base(context)
        {
        }
    }
}