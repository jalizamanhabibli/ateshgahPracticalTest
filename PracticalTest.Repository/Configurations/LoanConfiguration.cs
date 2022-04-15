using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticalTest.Core.Entities;

namespace PracticalTest.Repository.Configurations
{
    public class LoanConfiguration:IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount).HasMaxLength(5000).HasColumnType("money").IsRequired();
            builder.Property(x => x.InterestRate).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LoanPeriod).HasMaxLength(24).HasMaxLength(24).IsRequired();
            builder.Property(x => x.PayoutDate).IsRequired();
            builder.HasOne(x => x.Client).WithMany(x => x.Loans);
            builder.HasMany(x => x.Invoices).WithOne(x => x.Loan);
        }
    }
}