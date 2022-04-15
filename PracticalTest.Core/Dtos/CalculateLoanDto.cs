using System;

namespace PracticalTest.Core.Dtos
{
    public class CalculateLoanDto
    {
        public decimal Amount { get; set; }
        public int InterestRate { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime PayoutDate { get; set; }
        
    }
}