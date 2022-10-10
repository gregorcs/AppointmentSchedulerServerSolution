using Microsoft.Data.SqlClient;

namespace AppointmentSchedulerServer.Repositories
{
    public class SqlQueries
    {
        //connection
        private static readonly string DATABASE_CONNECTION = "Server=.;Database=AppointmentScheduler;integrated security=true";
        //tables
        private static readonly string TABLE_ACCOUNTS = "Accounts";

        //columns
        private static readonly string COLUMN_USERNAME = "Username";
        private static readonly string COLUMN_PASSWORD = "Password";

        //query strings
        /*        public static readonly string QUERY_SAVE_ACCOUNT = "INSERT INTO " + TABLE_ACCOUNTS + " (" + COLUMN_USERNAME + ", " 
                    + COLUMN_PASSWORD + ")" + " VALUES " + "@Username" + " AND " + "@Password";*/
        public static readonly string QUERY_SAVE_ACCOUNT = "INSERT INTO " + TABLE_ACCOUNTS + " VALUES " + "(" + "@Username" + ", " + "@Password" + ")";

        public static SqlConnection GetConnection()
        {
            try
            {
                return new(DATABASE_CONNECTION);
            }
            catch (Exception ex)
            {
                throw new Exception("Problem instantiating database " + ex.Message, ex);
            }
        }
    }
}
