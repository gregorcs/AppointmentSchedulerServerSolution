
namespace AppointmentSchedulerServer.Repositories
{
    public class SqlQueries
    {
        //query strings
        //insertions
        public const string QUERY_SAVE_ACCOUNT = "INSERT INTO Accounts (Username, Password, Email) OUTPUT Inserted.PK_AccountId VALUES (@Username, @Password, @Email)";
        public const string QUERY_SAVE_EMPLOYEE = "INSERT INTO Employees ( FK_Accounts_AccountID, Role, RoomNumber) " +
                                                    "OUTPUT Inserted.FK_Accounts_AccountID VALUES (@PK_AccountId, @Role, @RoomNumber)";
        //selects
        public const string QUERY_SELECT_BY_EMAIL_AND_PASSWORD = "SELECT * FROM Accounts WHERE Email = @Email";
        public const string QUERY_FIND_ACCOUNT_BY_ID = "SELECT * FROM Accounts WHERE PK_AccountId = @Id";
        public const string QUERY_FIND_ACCOUNT_BY_EMAIL = "SELECT (Email) FROM Accounts WHERE Email = @Email";
        public const string QUERY_SELECT_EVERYTHING_ACCOUNTS = "SELECT * FROM Accounts";

        public const string QUERY_ROLE_OF_EMPLOYEE = "SELECT (Role) FROM Employees WHERE COLUMN_FK_ACCOUNT_ID = @Id";

        public const string QUERY_FIND_EMPLOYEE_BY_ID = "SELECT * FROM Employees WHERE FK_Accounts_AccountID = @Id";

        //todo
        public const string QUERY_FIND_APPOINTMENTS_BY_ACCOUNT_ID = "SELECT * FROM Account_Appointment t1 INNER JOIN " +
            "ON appointment_appointmentId_FK = appointmentId WHERE AppointmentId = @Id";
        
        public const string QUERY_SAVE_APPOINTMENT = "";
        public const string QUERY_SAVE_ACCOUNT_JOIN_APPOINTMENT = "";
        public const string QUERY_SAVE_EMPLOYEE_JOIN_APPOINTMENT = "";
    }
}