using System;

namespace PracticalTest.Core.Dtos
{
    public class LoanDto
    {
        public int Id { get; set; }
        public string ClientUniqueId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public decimal Amount { get; set; }
        public DateTime PayoutDate { get; set; }

    }
}