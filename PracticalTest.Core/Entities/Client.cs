using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PracticalTest.Core.Entities
{
    public class Client:BaseEntity
    {
        private readonly ILazyLoader _lazyLoader;
        private ICollection<Loan> _loans;
        public Client()
        {
            
        }
        public Client(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        public string ClientUniqueId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNr { get; set; }

        public ICollection<Loan> Loans
        {
            get => _lazyLoader.Load(this, ref _loans);
            set => _loans = value;
        }

    }
}