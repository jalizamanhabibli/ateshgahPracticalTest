using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalTest.Core.Dtos;

namespace PracticalTest.Core.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<LoanDto>> GetAllAsync();
        Task<LoanDetailsDto> GetByIdAsync(int id);
        Task<bool> AddLoan(LoanInsertDto loanInsertDto);

    }
}