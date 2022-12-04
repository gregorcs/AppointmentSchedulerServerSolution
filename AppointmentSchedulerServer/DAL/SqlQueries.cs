
namespace AppointmentSchedulerServer.Repositories
{
    public class SqlQueries
    {
        //query strings
        //insertions
        public const string QUERY_SAVE_ACCOUNT = "INSERT INTO Accounts (Username, Password, Email) OUTPUT Inserted.Id VALUES (@Username, @Password, @Email)";
        public const string QUERY_SAVE_EMPLOYEE = "INSERT INTO Employees ( Accounts_Id, Role, RoomNumber) " +
                                                    "OUTPUT Inserted.Accounts_Id VALUES (@PK_AccountId, @Role, @RoomNumber)";
        //selects
        public const string QUERY_SELECT_BY_EMAIL_AND_PASSWORD = "SELECT * FROM Accounts WHERE Email = @Email";
        public const string QUERY_FIND_ACCOUNT_BY_ID = "SELECT * FROM Accounts WHERE Id = @Id";
        public const string QUERY_FIND_ACCOUNT_BY_EMAIL = "SELECT (Email) FROM Accounts WHERE Email = @Email";
        public const string QUERY_SELECT_EVERYTHING_ACCOUNTS = "SELECT * FROM Accounts";

        public const string QUERY_ROLE_OF_EMPLOYEE = "SELECT (Role) FROM Employees WHERE Accounts_Id = @Id";

        public const string QUERY_FIND_EMPLOYEE_BY_ID = "SELECT * FROM Employees WHERE Accounts_ID = @Id";

        //todo
        public const string QUERY_SAVE_APPOINTMENT_TYPE = "INSERT INTO AppointmentTypes(Name, Description) VALUES (@Name, @Description)";

        public const string QUERY_FIND_APPOINTMENT_TYPE_BY_ID = "SELECT * FROM AppointmentTypes WHERE Id = @AppointmentTypeId";

        public const string QUERY_FIND_APPOINTMENTS_BY_EMPLOYEE_ID = "SELECT * FROM Appointments t1 INNER JOIN Employees_Appointments t2 ON t1.Id = t2.Appointments_Id" +
            " WHERE t2.Accounts_Id = @EmployeeId";

        public const string QUERY_FIND_APPOINTMENTS_BY_CUSTOMER_ID = "SELECT * FROM Appointments WHERE Accounts_Id = @CustomerId";

        public const string QUERY_SAVE_APPOINTMENT = "INSERT INTO Appointments(AppointmentTypes_Id, Accounts_Id, Date, TimeSlot, IsApproved) OUTPUT Inserted.Id" +
            " VALUES (@AppointmentTypeId, @AccountId, @Date, @TimeSlot, @IsApproved)";

        public const string QUERY_SAVE_EMPLOYEE_JOIN_APPOINTMENT = "INSERT INTO Employees_Appointments(Appointments_Id, Accounts_Id) VALUES (@AppointmentId, @EmployeeId)";

        public const string QUERY_SELECT_TIMESLOT_BY_DATE = "SELECT TimeSlot FROM Appointments WHERE Date = @Date";
        public const string QUERY_FIND_APPOINTMENT_BY_ID = "SELECT * FROM Appointments WHERE Id = @Id";

        public const string QUERY_FIND_ALL_EMPLOYEES_AND_TIMESLOTS_BY_DATE = "SELECT t2.Accounts_Id, t1.Username, t2.RoomNumber, t3.Date, t3.TimeSlot FROM Accounts t1 " +
                                                        "INNER JOIN Employees t2 ON t1.Id = t2.Accounts_Id " +
                                                        "INNER JOIN Appointments t3 ON t2.Accounts_Id = t3.Accounts_Id " +
                                                        "WHERE t3.Date = @Date";

        public const string QUERY_FIND_UNAVAILABLE_TIMESLOTS_BY_EMPLOYE_AND_DATE = "SELECT t3.TimeSlot FROM Accounts t1 " +
                                                                            "INNER JOIN Employees t2 ON t1.Id = t2.Accounts_Id " +
                                                                            "INNER JOIN Appointments t3 ON t2.Accounts_Id = t3.Accounts_Id " +
                                                                            "WHERE t3.Date = @Date AND t2.Accounts_Id = @Id;";
    }
}