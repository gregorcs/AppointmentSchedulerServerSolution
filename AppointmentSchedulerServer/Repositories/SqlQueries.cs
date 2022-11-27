
using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Repositories
{
    public class SqlQueries
    {
        //tables
        private const string TABLE_ACCOUNTS = "Accounts";
        private const string TABLE_EMPLOYEES = "Employees";
        private const string TABLE_ACCOUNT_APPOINTMENT = "Account_Appointment";
        private const string TABLE_APPOINTMENT = "Appointment";

        //columns
        //Accounts
        private const string COLUMN_USERNAME = "Username";
        private const string COLUMN_PASSWORD = "Password";
        private const string COLUMN_ACCOUNT_ID = "PK_AccountId";
        private const string COLUMN_EMAIL = "Email";
        //Employees
        private const string COLUMN_FK_ACCOUNT_ID = "FK_Accounts_AccountID";
        private const string COLUMN_ROLE = "Role";
        private const string COLUMN_ROOM_NUMBER = "RoomNumber";
        //Appointments
        private const string COLUMN_APPOINTMENT_ID = "appointmentId";
        private const string COLUMN_APPOINTMENT_ID_FK = "appointment_appointmentId_FK";

        //query strings
        //insertions
        public const string QUERY_SAVE_ACCOUNT = "INSERT INTO " + TABLE_ACCOUNTS + "(" + COLUMN_USERNAME + ", "
            + COLUMN_PASSWORD + ", " + COLUMN_EMAIL + ") OUTPUT Inserted.PK_AccountId VALUES (@Username, @Password, @Email)";
        public const string QUERY_SAVE_EMPLOYEE = "INSERT INTO " + TABLE_EMPLOYEES + "(" + COLUMN_FK_ACCOUNT_ID + ", "
            + COLUMN_ROLE + ", " + COLUMN_ROOM_NUMBER + ") OUTPUT Inserted.FK_Accounts_AccountID VALUES (@PK_AccountId, @Role, @RoomNumber)";
        //selects
        public const string QUERY_SELECT_BY_EMAIL_AND_PASSWORD = "SELECT * FROM " + TABLE_ACCOUNTS + " WHERE "
            + COLUMN_EMAIL + " = " + "@Email";
        public const string QUERY_FIND_ACCOUNT_BY_ID = "SELECT * FROM " + TABLE_ACCOUNTS + " WHERE " + COLUMN_ACCOUNT_ID
            + " = " + "@Id";
        public const string QUERY_FIND_ACCOUNT_BY_EMAIL = "SELECT (Email) FROM " + TABLE_ACCOUNTS + " WHERE " + COLUMN_EMAIL
    + " = " + "@Email";
        public const string QUERY_SELECT_EVERYTHING_ACCOUNTS = "SELECT * FROM " + TABLE_ACCOUNTS;

        public const string QUERY_ROLE_OF_EMPLOYEE = "SELECT (Role) FROM " + TABLE_EMPLOYEES + " WHERE " + COLUMN_FK_ACCOUNT_ID
            + " = " + "@Id";

        public const string QUERY_FIND_EMPLOYEE_BY_ID = "SELECT * FROM " + TABLE_EMPLOYEES + " WHERE " + COLUMN_FK_ACCOUNT_ID
        + " = " + "@Id";

        //UNTESTED
        public const string QUERY_FIND_APPOINTMENTS_BY_ACCOUNT_ID = "SELECT * FROM " + TABLE_ACCOUNT_APPOINTMENT + " t1 INNER JOIN " + TABLE_APPOINTMENT +
             " ON " + COLUMN_APPOINTMENT_ID_FK + " = " + COLUMN_APPOINTMENT_ID + " WHERE " + COLUMN_APPOINTMENT_ID + " = @Id";

    }
}