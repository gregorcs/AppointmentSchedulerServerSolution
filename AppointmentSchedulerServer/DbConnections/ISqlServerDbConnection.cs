using System.Data;

namespace AppointmentSchedulerServer.DbConnections
{
    public interface ISqlServerDbConnection
    {
        object ConnectionString { get; }

        IDbConnection Connect();
    }
}