using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticalTest.Core.Dtos
{
    public class LoanDetailsDto
    {
        public int Id { get; set; }
        public ClientDto Client { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
        public int LoanPeriod { get; set; }
        public int InterestRate { get; set; }
        public DateTime PayoutDate { get; set; }
        public IEnumerable<InvoicesTableDto> Invoices { get; set; }
    }
}