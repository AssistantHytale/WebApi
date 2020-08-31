using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Contract;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Repository
{
    public class StoredProcedureRepository
    {
        public static async Task<Result> Execute(HytaleAssistantContext db, string query, List<StoredProcedureParameter> parameters, Action<DbDataReader> dbReader, Action<SqlCommand> sqlCommand = null, Action<Exception> exception = null, int numberOfRetries = 0, bool allowZeroRows = false)
        {
            int retries = 0;
            bool passed = false;
            Guid guid = Guid.NewGuid();
            string myException = $"Initialized. Guid:{guid}";

            do
            {
                if (!(db.Database.GetDbConnection() is SqlConnection conn)) return new Result(false, "DBConnection null");

                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    sqlCommand?.Invoke(command);
                    foreach (StoredProcedureParameter param in parameters ?? new List<StoredProcedureParameter>())
                    {
                        SqlParameter storedProcParam = command.Parameters.AddWithValue(param.Name, param.Value);
                        storedProcParam.SqlDbType = param.DataType;
                    }
                    await conn.OpenAsync();

                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            dbReader(reader);

                            passed = true;
                        }
                    }
                    else
                    {
                        retries = numberOfRetries;
                        if (allowZeroRows) passed = true;
                    }

                    retries++;

                    await reader.CloseAsync();
                }
                catch (Exception ex)
                {
                    retries++;
                    myException = ex.Message;
                    exception?.Invoke(ex);

                    passed = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            while ((retries < numberOfRetries) && (passed == false));

            return new Result(passed, myException);
        }

        public static async Task<Result> Execute(HytaleAssistantContext db, string query, List<StoredProcedureParameter> parameters, Action<DataSet> dbDataSetReader, Action<SqlCommand> sqlCommand = null, Action<Exception> exception = null, int numberOfRetries = 0)
        {
            bool passed;
            Guid guid = Guid.NewGuid();
            string myException = $"Initialized. Guid:{guid}";

            if (!(db.Database.GetDbConnection() is SqlConnection conn)) return new Result(false, "DBConnection null");
            DataSet dataSet = new DataSet();

            try
            {
                SqlCommand command = new SqlCommand(query, conn);
                sqlCommand?.Invoke(command);
                foreach (StoredProcedureParameter param in parameters ?? new List<StoredProcedureParameter>())
                {
                    SqlParameter storedProcParam = command.Parameters.AddWithValue(param.Name, param.Value);
                    storedProcParam.SqlDbType = param.DataType;
                }
                await conn.OpenAsync();

                using SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);
                dbDataSetReader(dataSet);
                passed = true;
            }
            catch (Exception ex)
            {
                myException = ex.Message;
                exception?.Invoke(ex);

                passed = false;
            }
            finally
            {
                conn.Close();
            }

            return new Result(passed, myException);
        }
    }
}
