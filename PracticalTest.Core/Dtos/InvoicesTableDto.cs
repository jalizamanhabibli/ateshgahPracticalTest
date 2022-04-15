using System;
using System.Text.Json.Serialization;

namespace PracticalTest.Core.Dtos
{
    public class InvoicesTableDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
    }
}