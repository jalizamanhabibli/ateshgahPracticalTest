using System;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PracticalTest.Core.Entities
{
    public class Invoice:BaseEntity
    {
        private readonly ILazyLoader _lazyLoader;
        private Loan _loan;
        public Invoice()
        {
        }

        public Invoice(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public int OrderNr { get; set; }
        public int LoanId { get; set; }

        public Loan Loan
        {
            get => _lazyLoader.Load(this, ref _loan);
            set => _loan = value;
        }

    }
}