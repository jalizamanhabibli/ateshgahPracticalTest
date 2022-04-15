using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.Core.Services;

namespace PracticalTest.UI.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<IActionResult> GetAll()
        {
            var result =  await _clientService.GetAll();
            return Json(result);
        }
    }
}
