using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PracticalTest.Core.Dtos;
using PracticalTest.Core.Entities;
using PracticalTest.Core.Repositories;
using PracticalTest.Core.Repositories.Invoice;
using PracticalTest.Core.Services;
using Serilog;

namespace PracticalTest.Service.Services
{
    public class InvoiceService:IInvoiceService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<InvoicesTableDto>> GetInvoiceListByLoanDataProcAsync(CalculateLoanDto calculateLoanDto)
        {
            IEnumerable<InvoicesTableDto> resultDto;
            try
            {
                Log.Information("Start GetInvoiceListByLoanDataProcAsync");
                var calculateLoan = _mapper.Map<Loan>(calculateLoanDto);
                var result = await _uniteOfWork.InvoiceRepository.GetInvoiceListByLoanDataProcAsync(calculateLoan);
                resultDto = _mapper.Map<IEnumerable<InvoicesTableDto>>(result);
                foreach (var invoicesTableDto in resultDto)
                {
                    invoicesTableDto.InvoiceNo = invoicesTableDto.Id.ToString("0000");
                }
                Log.Information("Stop GetInvoiceListByLoanDataProcAsync");
            }
            catch (Exception e)
            {
                Log.Information(e,"Error GetInvoiceListByLoanDataProcAsync");
                throw;
            }
            return resultDto;

        }
    }
}