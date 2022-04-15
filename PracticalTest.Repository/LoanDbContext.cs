using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Core.Entities;

namespace PracticalTest.Repository
{
    public class LoanDbContext:DbContext
    {
        public LoanDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}