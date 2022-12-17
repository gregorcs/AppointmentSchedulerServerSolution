using Microsoft.Data.SqlClient;
using System.Data;

namespace AppointmentSchedulerServer.DbConnections
{
    public class SqlServerDbConnection : ISqlServerDbConnection
    {
        private readonly string _connectionString;
        public SqlServerDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object ConnectionString { get; }

        public IDbConnection Connect()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
