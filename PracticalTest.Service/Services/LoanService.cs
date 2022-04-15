
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Core.Dtos;
using PracticalTest.Core.Entities;
using PracticalTest.Core.Repositories;
using PracticalTest.Core.Repositories.Loan;
using PracticalTest.Core.Services;
using Serilog;

namespace PracticalTest.Service.Services
{
    public class LoanService : ILoanService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private IMapper _mapper;

        public LoanService(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanDto>> GetAllAsync()
        {
            IEnumerable<LoanDto> resultDto;
            try
            {
                Log.Information("Start GetAllAsync");
                var result = await _uniteOfWork.LoanRepository.GetAll().ToListAsync();
                resultDto = _mapper.Map<IEnumerable<LoanDto>>(result);
                Log.Information("End GetAllAsync");
            }
            catch (Exception e)
            {
                Log.Fatal(e,"Error GetAllAsync");
                throw;
            }
            
            return resultDto;
        }

        public async Task<LoanDetailsDto> GetByIdAsync(int id)
        {
            try
            {
                Log.Information("Start GetAllAsync");
                var loan = await _uniteOfWork.LoanRepository.GetByIdAsync(id);
                var result = _mapper.Map<LoanDetailsDto>(loan);
                Log.Information("End GetAllAsync");
                return result;
            }
            catch (Exception e)
            {
                Log.Fatal(e,"Error GetAllAsync");
                throw;
            }
            
        }

        public async Task<bool> AddLoan(LoanInsertDto loanInsertDto)
        {
            Log.Information("Start AddLoan");
            await using var transaction = await _uniteOfWork.BeginTransactionAsync();
            try
            {
                int orderNr = 1;
                var loan = _mapper.Map<Loan>(loanInsertDto);
                var client = await _uniteOfWork.ClientRepository.GetByIdAsync(loan.ClientId);
                loan.Client = client;
                var resultLoan = await _uniteOfWork.LoanRepository.AddAsync(loan);
                await _uniteOfWork.SaveAsync();
                var invoices = await _uniteOfWork.InvoiceRepository.GetInvoiceListByLoanDataProcAsync(loan);
                foreach (var invoice in invoices)
                {
                    invoice.Id = 0;
                    invoice.OrderNr = orderNr;
                    orderNr++;
                    invoice.LoanId = loan.Id;
                    invoice.Loan = loan;
                }
                var invoicesResult = await _uniteOfWork.InvoiceRepository.AddRangeAsync(invoices);
                await _uniteOfWork.SaveAsync();
                await transaction.CommitAsync();
                Log.Information("End AddLoan");
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                Log.Fatal(e,"Error AddLoan");
                throw;
            }


            return true;


        }
    }
}