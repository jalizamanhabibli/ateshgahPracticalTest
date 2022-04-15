using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using PracticalTest.Core.Repositories;
using PracticalTest.Core.Repositories.Invoice;

namespace PracticalTest.Repository.Repositories.Invoice
{
    public class InvoiceRepository:Repository<Core.Entities.Invoice>,IInvoiceRepository
    {
        public InvoiceRepository(LoanDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Core.Entities.Invoice>> GetInvoiceListByLoanDataProcAsync(Core.Entities.Loan loan)
        {
            await using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "GetInvoiceListByLoanDataProc";
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@pAmount",
                SqlDbType = SqlDbType.Money,
                Size = -1,
                Direction = ParameterDirection.Input,
                Value = loan.Amount
            });
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@pInterestRate",
                SqlDbType = SqlDbType.Int,
                Size = 10,
                Direction = ParameterDirection.Input,
                Value = loan.InterestRate
            });
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@pLoanPeriod",
                SqlDbType = SqlDbType.Int,
                Size = 10,
                Direction = ParameterDirection.Input,
                Value = loan.LoanPeriod
            });
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@pPayoutDate",
                SqlDbType = SqlDbType.DateTime2,
                Size = -1,
                Direction = ParameterDirection.Input,
                Value = loan.PayoutDate
            });
            command.Parameters.Add(new SqlParameter
            {
                ParameterName = "@pResult",
                SqlDbType = SqlDbType.NVarChar,
                Size = -1,
                Direction = ParameterDirection.Output
            });
            command.CommandType = CommandType.StoredProcedure;
            
            await _context.Database.OpenConnectionAsync();
            command.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction();
            await command.ExecuteNonQueryAsync();
            await _context.Database.CloseConnectionAsync();
            var result = command.Parameters["@pResult"].Value!.ToString();

            return JsonConvert.DeserializeObject<IEnumerable<Core.Entities.Invoice>>(result);
        }
    }
}