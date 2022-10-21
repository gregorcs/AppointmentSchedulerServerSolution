
namespace AppointmentSchedulerServer.Repositories
{
    public class SqlQueries
    {
        //tables
        private static readonly string TABLE_ACCOUNTS = "Accounts";

        //columns
        private static readonly string COLUMN_USERNAME = "Username";
        private static readonly string COLUMN_PASSWORD = "Password";
        private static readonly string COLUMN_ACCOUNT_ID = "PK_Account_Id";
        private static readonly string COLUMN_EMAIL = "Email";

        //query strings
        public static readonly string QUERY_SELECT_BY_EMAIL_AND_PASSWORD = "SELECT * FROM " + TABLE_ACCOUNTS + " WHERE " 
            + COLUMN_EMAIL + " = " + "@Email";
        public static readonly string QUERY_SAVE_ACCOUNT = "INSERT INTO " + TABLE_ACCOUNTS + "(" + COLUMN_USERNAME + ", " 
            + COLUMN_PASSWORD + ", " + COLUMN_EMAIL + ") OUTPUT Inserted.PK_Account_Id VALUES (@Username, @Password, @Email)";
        public static readonly string FIND_BY_ID = "SELECT * FROM " + TABLE_ACCOUNTS + " WHERE " + COLUMN_ACCOUNT_ID 
            + " = " + "@Id";
        public static readonly string SELECT_EVERYTHING_ACCOUNTS = "SELECT * FROM " + TABLE_ACCOUNTS;
        /*public static readonly string EXISTS_BY_ID = "SELECT " + COLUMN_ACCOUNT_ID + " FROM " + TABLE_ACCOUNTS 
            + ;*/
    }
}