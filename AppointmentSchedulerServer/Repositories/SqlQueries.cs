
namespace AppointmentSchedulerServer.Repositories
{
    public class SqlQueries
    {
        //tables
        private const string TABLE_ACCOUNTS = "Accounts";
        private const string TABLE_EMPLOYEES = "Employees";

        //columns
        //Accounts
        private const string COLUMN_USERNAME = "Username";
        private const string COLUMN_PASSWORD = "Password";
        private const string COLUMN_ACCOUNT_ID = "PK_AccountId";
        private const string COLUMN_EMAIL = "Email";
        //Employees
        private const string COLUMN_FK_ACCOUNT_ID = "FK_Accounts_AccountID";
        private const string COLUMN_ROLE = "Role";

        //query strings
        public const string QUERY_SELECT_BY_EMAIL_AND_PASSWORD = "SELECT * FROM " + TABLE_ACCOUNTS + " WHERE "
            + COLUMN_EMAIL + " = " + "@Email";
        public const string QUERY_SAVE_ACCOUNT = "INSERT INTO " + TABLE_ACCOUNTS + "(" + COLUMN_USERNAME + ", "
            + COLUMN_PASSWORD + ", " + COLUMN_EMAIL + ") OUTPUT Inserted.PK_AccountId VALUES (@Username, @Password, @Email)";
        public const string FIND_BY_ID = "SELECT * FROM " + TABLE_ACCOUNTS + " WHERE " + COLUMN_ACCOUNT_ID
            + " = " + "@Id";
        public const string SELECT_EVERYTHING_ACCOUNTS = "SELECT * FROM " + TABLE_ACCOUNTS;
        public const string QUERY_SAVE_EMPLOYEE = "INSERT INTO " + TABLE_EMPLOYEES + "(" + COLUMN_FK_ACCOUNT_ID + ", "
            + COLUMN_ROLE + ") OUTPUT Inserted.FK_Accounts_AccountID VALUES (@Id, @Role)";
    }
}