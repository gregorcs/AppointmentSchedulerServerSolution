using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.DAL
{
    public class SqlQueries
    {
        //query strings
        //INSERT
            //account
        public const string QUERY_SAVE_ACCOUNT = "INSERT INTO Accounts (Username, Password, Email) OUTPUT Inserted.Id VALUES (@Username, @Password, @Email)";
            //employee
        public const string QUERY_SAVE_EMPLOYEE = "INSERT INTO Employees ( Accounts_Id, Role, RoomNumber) " +
                                                    "OUTPUT Inserted.Accounts_Id VALUES (@Id, @Role, @RoomNumber)";
            //appointment
        public const string QUERY_SAVE_APPOINTMENT_TYPE = "INSERT INTO AppointmentTypes(Name, Description) VALUES (@Name, @Description)";
        public const string QUERY_SAVE_APPOINTMENT = "INSERT INTO Appointments(AppointmentTypes_Id, Accounts_Id, Date, TimeSlot, IsApproved, Message) OUTPUT Inserted.Id" +
                                                        " VALUES (@AppointmentTypeId, @AccountId, @Date, @TimeSlot, @IsApproved, @Message)";
        public const string QUERY_SAVE_EMPLOYEE_JOIN_APPOINTMENT = "INSERT INTO Employees_Appointments(Appointments_Id, Accounts_Id) VALUES (@AppointmentId, @EmployeeId)";

        //SELECT
            //account
        public const string QUERY_FIND_BY_EMAIL_AND_PASSWORD = "SELECT * FROM Accounts WHERE Email = @Email";
        public const string QUERY_FIND_ACCOUNT_BY_ID = "SELECT * FROM Accounts WHERE Id = @Id";
        public const string QUERY_FIND_ACCOUNT_BY_EMAIL = "SELECT (Email) FROM Accounts WHERE Email = @Email";
        public const string QUERY_FIND_EVERYTHING_ACCOUNTS = "SELECT * FROM Accounts";
            //employee
        public const string QUERY_FIND_ROLE_OF_EMPLOYEE = "SELECT (Role) FROM Employees WHERE Accounts_Id = @Id";

        public const string QUERY_FIND_EMPLOYEE_BY_ID = "SELECT * FROM Employees WHERE Accounts_ID = @Id";
        public const string QUERY_FIND_ALL_EMPLOYEES_AND_TIMESLOTS_BY_DATE = "SELECT t2.Accounts_Id, t1.Username, t2.RoomNumber " +
                                                                                "FROM Accounts t1 " +
                                                                                "INNER JOIN Employees t2 ON t1.Id = t2.Accounts_Id " +
                                                                                "LEFT JOIN (SELECT Date, Accounts_Id " +
                                                                                "FROM Appointments " +
                                                                                "WHERE Date = @Date) t3 ON t2.Accounts_Id = t3.Accounts_Id " +
                                                                                "GROUP BY t2.Accounts_Id, t2.RoomNumber, t1.Username";

            //appointment
        public const string QUERY_FIND_APPOINTMENT_TYPE_BY_ID = "SELECT * FROM AppointmentTypes WHERE Id = @AppointmentTypeId";

        public const string QUERY_FIND_APPOINTMENTS_BY_EMPLOYEE_ID = "SELECT appointment.Id, Date, TimeSlot, IsApproved, customer.Username, customer.Email, appointmentType.Name, appointmentType.Description " +
                                                                        "FROM Appointments appointment " +
                                                                        "INNER JOIN Accounts customer ON appointment.Accounts_Id = customer.Id " +
                                                                        "INNER JOIN AppointmentTypes appointmentType ON appointment.AppointmentTypes_Id = appointmentType.Id " +
                                                                        "INNER JOIN Employees_Appointments employee ON appointment.Id = employee.Appointments_Id WHERE employee.Accounts_Id = @Id";

        public const string QUERY_FIND_APPOINTMENTS_BY_CUSTOMER_ID = "SELECT appointment.Id, Date, TimeSlot, IsApproved, customer.Username, customer.Email, appointmentType.Name, appointmentType.Description " +
                                                                        "FROM Appointments appointment INNER JOIN Accounts customer ON appointment.Accounts_Id = customer.Id " +
                                                                        "INNER JOIN AppointmentTypes appointmentType ON appointment.AppointmentTypes_Id = appointmentType.Id " +
                                                                        "INNER JOIN Employees_Appointments employee ON appointment.Id = employee.Appointments_Id WHERE appointment.Accounts_Id = @Id";

        public const string QUERY_FIND_EMPLOYEES_FOR_APPOINTMENT = "SELECT t1.Id, t1.Username, Role, Email, Role, RoomNumber  " +
                                                                    "FROM Accounts t1 " +
                                                                    "INNER JOIN Employees t2 ON t1.Id = t2.Accounts_Id " +
                                                                    "INNER JOIN Employees_Appointments t3 ON t2.Accounts_Id = t3.Accounts_Id " +
                                                                    "WHERE t3.Appointments_Id = @Id";

        public const string QUERY_FIND_TIMESLOT_BY_DATE = "SELECT TimeSlot FROM Appointments WHERE Date = @Date";
        public const string QUERY_FIND_APPOINTMENT_BY_ID = "SELECT * FROM Appointments WHERE Id = @Id";

        public const string QUERY_FIND_UNAVAILABLE_TIMESLOTS_BY_EMPLOYE_AND_DATE = "SELECT t1.TimeSlot FROM Appointments t1 INNER JOIN Employees_Appointments t2 ON t1.Id = t2.Appointments_Id WHERE t2.Accounts_Id= @Id AND Date = @Date";


        public const string QUERY_FIND_ALL_APPOINTMENT_TYPES = "SELECT * FROM AppointmentTypes";

        public const string QUERY_FIND_EMPLOYEE_BY_APPOINTMENT_TYPE = "SELECT t1.Accounts_Id, Username, Email, Role, RoomNumber FROM Employees t1 INNER JOIN Accounts t2 ON t1.Accounts_Id = t2.Id " +
                                                                        "INNER JOIN Employees_AppointmentTypes t3 ON t1.Accounts_Id = t3.Accounts_Id " +
                                                                        "WHERE t3.AppointmentTypes_Id = @AppointmentTypes_Id";

        public const string QUERY_COUNT_APPOINTMENTS_FOR_EMPLOYEE_TIME_AND_DATE = "SELECT COUNT(*) AS Amount FROM Employees_Appointments t1 INNER JOIN  Appointments t2 ON t1.Appointments_Id = t2.Id WHERE t1.Accounts_Id = @Id AND TimeSlot = @Timeslot AND Date = @Date";
        public const string QUERY_FIND_ALL_EMPLOYEES = "SELECT * FROM Employees t1 INNER JOIN Accounts t2 ON t1.Accounts_Id = t2.Id";
    }
}