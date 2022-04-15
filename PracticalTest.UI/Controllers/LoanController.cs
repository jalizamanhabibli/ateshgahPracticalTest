using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.Core.Dtos;
using PracticalTest.Core.Services;

namespace PracticalTest.UI.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _loanService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Save()
        {

            return View("SaveLoan");
        }


        [HttpPost]
        public async Task<IActionResult> Save(LoanInsertDto insertDto)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveLoan",insertDto);
            }

            var result = await _loanService.AddLoan(insertDto);
            return Redirect("/Loan");
        }

        public async Task<IActionResult> LoanDetails(int id)
        {
            var result = await _loanService.GetByIdAsync(id);
            return View("LoadDetails", result);
        }

    }
}
