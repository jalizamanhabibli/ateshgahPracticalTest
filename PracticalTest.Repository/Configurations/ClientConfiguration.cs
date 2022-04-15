using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticalTest.Core.Entities;

namespace PracticalTest.Repository.Configurations
{
    public class ClientConfiguration:IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clinets");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ClientUniqueId).IsUnique();

            builder.Property(x => x.ClientUniqueId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.TelephoneNr).IsRequired();
            builder.HasMany(x => x.Loans).WithOne(x => x.Client);

            builder.HasData(new Client()
            {
                Id = 1,
                ClientUniqueId = "123456A",
                Name = "Ahmed",
                Surname = "Akhtarov",
                TelephoneNr ="+372 937262323"
            },new Client()
            {
                Id = 2,
                ClientUniqueId = "123456B",
                Name = "John",
                Surname = "Deerer",
                TelephoneNr = "+372 937262424"
            });
        }
    }
}