using AppointmentSchedulerServer.Entities;
using AppointmentSchedulerServer.Exceptions;
using Microsoft.Data.SqlClient;

namespace AppointmentSchedulerServer.Repositories
{
    public class AccountRepository : IAccountRepository

    {
        public Task Delete(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<Account> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByNameAndPassword(Account entity)
        {
            using SqlConnection connection = SqlQueries.GetConnection();

            try
            {
                await connection.OpenAsync();
            }
            catch (Exception ex)
            {
                throw new ConnectionProblemException("could not initialize connection", ex);
            }

            SqlCommand cmd = connection.CreateCommand();

            SqlParameter usernameParameter = new("@Username", System.Data.SqlDbType.NVarChar);
            /*            SqlParameter passwordParameter = new("@Password", System.Data.SqlDbType.Binary);*/
            SqlParameter passwordParameter = new("@Password", System.Data.SqlDbType.NVarChar);

            usernameParameter.Value = entity.Username;
            passwordParameter.Value = entity.Password;

            cmd.Parameters.Add(usernameParameter);
            cmd.Parameters.Add(passwordParameter);

            cmd.CommandText = SqlQueries.QUERY_SELECT_BY_USERNAME_AND_PASSWORD;
            int rowsAffected;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader.GetString(1), reader.GetString(2)));
                        return (entity.Username.Equals(reader.GetString(1)) && entity.Password.Equals(reader.GetString(2)));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new LoginFailedException("Login query failed", ex);
            }

            //TODO lots of stuff to fix, save PW as binary or base64 nvarchar, add error handling all the way up to api declaration, return the created account
            await connection.CloseAsync();
            return false;
        }

        public Task<IEnumerable<Account>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> FindAllById(IEnumerable<Guid> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<Account> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save(Account entity)
        {
            using SqlConnection connection = SqlQueries.GetConnection();

            try
            {
                await connection.OpenAsync();
            } catch (Exception ex)
            {
                throw new ConnectionProblemException("could not initialize connection", ex);
            }

            SqlCommand cmd = connection.CreateCommand();

            SqlParameter usernameParameter = new("@Username", System.Data.SqlDbType.NVarChar);
            /*            SqlParameter passwordParameter = new("@Password", System.Data.SqlDbType.Binary);*/
            SqlParameter passwordParameter = new("@Password", System.Data.SqlDbType.NVarChar);

            usernameParameter.Value = entity.Username;
            passwordParameter.Value = entity.Password;

            cmd.Parameters.Add(usernameParameter);
            cmd.Parameters.Add(passwordParameter);

            cmd.CommandText = SqlQueries.QUERY_SAVE_ACCOUNT;
            int rowsAffected;

            try
            {
                rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected <= 0)
                {
                    //todo add something proper here :)
                    throw new Exception();
                }
            } catch(Exception ex) {
                throw new DatabaseInsertionException("Could not save account", ex);
            }

            //TODO lots of stuff to fix, save PW as binary or base64 nvarchar, add error handling all the way up to api declaration, return the created account
            await connection.CloseAsync();
            return rowsAffected;
        }

        public Task<int> SaveAll(IEnumerable<Account> entities)
        {
            throw new NotImplementedException();
        }
    }
}
