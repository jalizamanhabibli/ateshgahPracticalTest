using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticalTest.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientUniqueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "money", maxLength: 5000, nullable: false),
                    InterestRate = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    LoanPeriod = table.Column<int>(type: "int", maxLength: 24, nullable: false),
                    PayoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Clinets_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clinets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNr = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clinets",
                columns: new[] { "Id", "ClientUniqueId", "Name", "Surname", "TelephoneNr" },
                values: new object[] { 1, "123456A", "Ahmed", "Akhtarov", "+372 937262323" });

            migrationBuilder.InsertData(
                table: "Clinets",
                columns: new[] { "Id", "ClientUniqueId", "Name", "Surname", "TelephoneNr" },
                values: new object[] { 2, "123456B", "John", "Deerer", "+372 937262424" });

            migrationBuilder.CreateIndex(
                name: "IX_Clinets_ClientUniqueId",
                table: "Clinets",
                column: "ClientUniqueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_LoanId",
                table: "Invoices",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ClientId",
                table: "Loans",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Clinets");
        }
    }
}
