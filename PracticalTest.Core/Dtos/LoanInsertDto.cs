using System;

namespace PracticalTest.Core.Dtos
{
    public class LoanInsertDto
    {
        public int ClientId { get; set; }
        public decimal Amount { get; set; }
        public int LoanPeriod { get; set; }
        public int InterestRate { get; set; }
        public DateTime PayoutDate { get; set; }

    }
}