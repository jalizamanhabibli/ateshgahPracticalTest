using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PracticalTest.Core.Entities
{
    public class Loan:BaseEntity
    {
        private readonly ILazyLoader _lazyLoader;
        private Client _client;
        private ICollection<Invoice> _invoices;
        public Loan()
        {
        }

        public Loan(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        public decimal Amount { get; set; }
        public int InterestRate { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime PayoutDate { get; set; }
        public int ClientId { get; set; }

        public Client Client
        {
            get => _lazyLoader.Load(this, ref _client);
            set => _client = value;
        }

        public ICollection<Invoice> Invoices
        {
            get => _lazyLoader.Load(this, ref _invoices);
            set => _invoices = value;
        }
    }
}