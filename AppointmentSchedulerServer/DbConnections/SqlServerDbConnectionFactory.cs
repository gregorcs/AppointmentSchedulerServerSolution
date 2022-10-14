using Microsoft.Data.SqlClient;
using System.Data;

namespace AppointmentSchedulerServer.DbConnections
{
    public class SqlServerDbConnectionFactory
    {
        private readonly string _connectionString;
        public SqlServerDbConnectionFactory(string connectionString)
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
