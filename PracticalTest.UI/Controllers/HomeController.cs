using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PracticalTest.Core.Entities;
using PracticalTest.Core.Repositories;
using PracticalTest.Core.Repositories.Loan;

namespace PracticalTest.UI.Controllers
{
    public class HomeController : Controller
    {
        private IUniteOfWork _uniteOfWork;

        public HomeController(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
