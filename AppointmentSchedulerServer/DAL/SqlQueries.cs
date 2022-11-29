
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
        public const string QUERY_SAVE_APPOINTMENT_TYPE = "INSERT INTO AppointmentTypes(Name, Description) VALUES (@Name, @Description)";

        public const string QUERY_FIND_APPOINTMENT_TYPE_BY_ID = "SELECT * FROM AppointmentTypes WHERE PK_AppointmentTypeId = @AppointmentTypeId";

        public const string QUERY_FIND_APPOINTMENTS_BY_EMPLOYEE_ID = "SELECT * FROM Appointments t1 INNER JOIN Employees_Appointments t2 ON t1.PK_AppointmentId = t2.FK_Appointments_AppointmentId" +
            "WHERE t2.FK_Accounts_AccountId = @EmployeeId";

        public const string QUERY_FIND_APPOINTMENTS_BY_CUSTOMER_ID = "SELECT * FROM Appointments WHERE FK_Accounts_AccountId = @CustomerId";

        public const string QUERY_SAVE_APPOINTMENT = "INSERT INTO Appointments(FK_AppointmentTypes_AppointmentTypeId, FK_Accounts_AccountId, Date, TimeSlot) OUTPUT Inserted.PK_AppointmentId" +
            "VALUES (@AppointmentTypeId, @CustomerId, @Date, @TimeSlot)";

        public const string QUERY_SAVE_EMPLOYEE_JOIN_APPOINTMENT = "INSERT INTO Employees_Appointments(FK_Appointments_AppointmentId, FK_Accounts_AccountId) VALUES (@AppointmentId, @EmployeeId)";

        public const string QUERY_SELECT_TIMESLOT_BY_DATE = "SELECT TimeSlot FROM Appointments WHERE Date = @Date";


    }
}