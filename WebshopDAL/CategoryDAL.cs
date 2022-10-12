using System.Data.SqlClient;
using WebshopInterface;

namespace WebshopDAL
{
    public class CategoryDAL : ICategoryContainer
    {
        SqlConnection SqlConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi479257;User Id=dbi479257;Password=Dagal555;");

        public bool CreateCategory(string categoryname)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Category(CategoryName) VALUES (@CatergoryName)", SqlConnection);
            SqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("CategoryName", categoryname);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                SqlConnection.Close();
            }
                return true;
        }
            public  List<CategoryDTO> GetAllCategories()
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Category", SqlConnection);
                SqlConnection.Open();
                List<CategoryDTO> Result = new List<CategoryDTO>();
                try
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    // zet het resultaat in de reader
                    while (reader.Read())
                    {
                        Result.Add(new CategoryDTO()
                        {
                            CategoryID = (int)reader["CategoryID"],
                            CategoryName = (string)reader["CategoyName"],
                        });
                    };
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
                finally
                {
                    SqlConnection.Close();
                }
                return Result;
            } 
        public void DeleteCategoryID(int categoryID)
        {
            throw new NotImplementedException();
        }
    }
    
}