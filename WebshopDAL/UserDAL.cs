using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopDAL
{
    public class UserDAL : IUserContainer
    {
        SqlConnection sqlConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi479257_webshopdtb;User Id=dbi479257_webshopdtb;Password=Dagal555");

        public bool CreateUser(UserDTO userDTO)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [User] (Email, Password, FirstName, LastName, IsAdmin) VALUES (@Email, @Password, @FirstName, @LastName, @IsAdmin)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Email", userDTO.Email);
            sqlCommand.Parameters.AddWithValue("@Password", userDTO.Password);
            sqlCommand.Parameters.AddWithValue("@FirstName", userDTO.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", userDTO.LastName);
            sqlCommand.Parameters.AddWithValue("@IsAdmin", userDTO.IsAdmin);
            try
            {
                SqlDataReader insert = sqlCommand.ExecuteReader();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return true;
        }

        public bool UserExist(UserDTO userDTO)
        {

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Email", userDTO.Email);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    sqlConnection.Close();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            sqlConnection.Close();
            return false;
        }

        public bool UserExistsByEmailAndPassword(string email, string password)
        {

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email AND Password = @Password", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@Password", password);
                var result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    sqlConnection.Close();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return false;
        }

        public UserDTO GetUserByEmailAndPassword(UserDTO userDTO)
        {

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email AND Password = @Password", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Email", userDTO.Email);
                sqlCommand.Parameters.AddWithValue("@Password", userDTO.Password);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    userDTO.UserID = (int)reader["UserID"];
                    userDTO.Email = (string)reader["Email"];
                    userDTO.Password = (string)reader["Password"];
                    userDTO.FirstName = (string)reader["FirstName"];
                    userDTO.IsAdmin = (bool)reader["IsAdmin"];
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return userDTO;
        }
        public UserDTO GetUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}