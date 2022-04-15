using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticalTest.Core.Entities;

namespace PracticalTest.Repository.Configurations
{
    public class InvoiceConfiguration:IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount).HasColumnType("money").IsRequired();
            builder.Property(x => x.DueDate).IsRequired();
            builder.Property(x => x.OrderNr).IsRequired();
            builder.HasOne(x => x.Loan).WithMany(x => x.Invoices);
        }
    }
}