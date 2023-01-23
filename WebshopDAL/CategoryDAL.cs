using System.Data.SqlClient;
using WebshopInterface;

namespace WebshopDAL
{
    public class CategoryDAL : ICategoryContainer
    {
        SqlConnection SqlConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi479257_webshopdtb;User Id=dbi479257_webshopdtb;Password=Dagal555");

        public bool CreateCategory(string categoryname)
        {
            bool output = false;
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Category(CategoryName) VALUES (@CategoryName)", SqlConnection);
                sqlCommand.Parameters.AddWithValue("CategoryName", categoryname);
                var result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    output = true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                SqlConnection.Close();
            }
            return output;
        }
        public List<CategoryDTO> GetAllCategories()
        {
            List<CategoryDTO> Result = new List<CategoryDTO>();
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Category", SqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                // zet het resultaat in de reader
                while (reader.Read())
                {
                    Result.Add(new CategoryDTO()
                    {
                        CategoryID = (int)reader["CategoryID"],
                        CategoryName = (string)reader["CategoryName"],
                    });
                };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                SqlConnection.Close();
            }
            return Result;
        }
        public bool CategoryExist(string categoryname)
        {
            bool output = false;
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Category WHERE CategoryName = @CategoryName", SqlConnection);

                sqlCommand.Parameters.AddWithValue("CategoryName", categoryname);
                var result = sqlCommand.ExecuteReader();
                output = result.HasRows;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                SqlConnection.Close();
            }
            return output;
        }

        public string GetCategoryNameByCategoryID(int categoryID)
        {
            string categoryName = "";
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT [CategoryName] FROM Category WHERE CategoryID = @CategoryID", SqlConnection);
                sqlCommand.Parameters.AddWithValue("@CategoryID", categoryID);
                SqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                   // categoryName = (string)reader[0];
                    categoryName = (string)reader["CategoryName"];
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                SqlConnection.Close();
            }
            return categoryName;
        }
        public void DeleteCategoryID(int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}