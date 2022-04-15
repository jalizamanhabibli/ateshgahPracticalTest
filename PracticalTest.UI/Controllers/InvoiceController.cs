using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.Core.Dtos;
using PracticalTest.Core.Services;

namespace PracticalTest.UI.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> GetInvoices(CalculateLoanDto calculateLoanDto)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var result = await _invoiceService.GetInvoiceListByLoanDataProcAsync(calculateLoanDto);
            return Json(result);
        }
    }
}
