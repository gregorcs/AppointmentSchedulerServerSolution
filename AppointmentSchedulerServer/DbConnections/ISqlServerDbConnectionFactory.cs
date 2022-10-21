using System.Data;

namespace AppointmentSchedulerServer.DbConnections
{
    public interface ISqlServerDbConnectionFactory
    {
        object ConnectionString { get; }

        IDbConnection Connect();
    }
}