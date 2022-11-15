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
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [User] (Email, Password, FirstName, LastName, IsAdmin) VALUES (@Email, @Password, @FirstName, @LastName, @IsAdmin)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Email", userDTO.Email);
            sqlCommand.Parameters.AddWithValue("@Password", userDTO.Password);
            sqlCommand.Parameters.AddWithValue("@FirstName", userDTO.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", userDTO.LastName);
            sqlCommand.Parameters.AddWithValue("@IsAdmin", userDTO.IsAdmin);
            sqlConnection.Open();
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
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Email", userDTO.Email);
            sqlConnection.Open();

            try
            {
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
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email AND Password = @Password", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Email", email);
            sqlCommand.Parameters.AddWithValue("@Password", password);

            sqlConnection.Open();
            try
            {
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
            sqlConnection.Close();
            return false;
        }
        public UserDTO GetUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByEmailAndPassword(UserDTO userDTO)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [User] WHERE Email = @Email AND Password = @Password", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Email", userDTO.Email);
            sqlCommand.Parameters.AddWithValue("@Password", userDTO.Password);

            sqlConnection.Open();
            try
            {
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
            sqlConnection.Close();
            return userDTO;
        }
    }
}