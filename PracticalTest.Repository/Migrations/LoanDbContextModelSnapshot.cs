// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticalTest.Repository;

namespace PracticalTest.Repository.Migrations
{
    [DbContext(typeof(LoanDbContext))]
    partial class LoanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PracticalTest.Core.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientUniqueId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientUniqueId")
                        .IsUnique();

                    b.ToTable("Clinets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientUniqueId = "123456A",
                            Name = "Ahmed",
                            Surname = "Akhtarov",
                            TelephoneNr = "+372 937262323"
                        },
                        new
                        {
                            Id = 2,
                            ClientUniqueId = "123456B",
                            Name = "John",
                            Surname = "Deerer",
                            TelephoneNr = "+372 937262424"
                        });
                });

            modelBuilder.Entity("PracticalTest.Core.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<int>("OrderNr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("PracticalTest.Core.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasMaxLength(5000)
                        .HasColumnType("money");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("InterestRate")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<int>("LoanPeriod")
                        .HasMaxLength(24)
                        .HasColumnType("int");

                    b.Property<DateTime>("PayoutDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("PracticalTest.Core.Entities.Invoice", b =>
                {
                    b.HasOne("PracticalTest.Core.Entities.Loan", "Loan")
                        .WithMany("Invoices")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("PracticalTest.Core.Entities.Loan", b =>
                {
                    b.HasOne("PracticalTest.Core.Entities.Client", "Client")
                        .WithMany("Loans")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("PracticalTest.Core.Entities.Client", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("PracticalTest.Core.Entities.Loan", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
