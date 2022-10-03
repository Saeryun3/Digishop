using System.Data.SqlClient;
using WebshopIntertface;

namespace WebshopDAL
{
    public class CategoryDAL : ICategoryContainer
    {       
        SqlConnection SqlConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi479257;User Id=dbi479257;Password=Dagal555;");
        // query create category
        public void CreateCategory(CategoryDTO categoryDTO)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Category(CategoryName) VALUES (@CatergoryName)", SqlConnection);
            SqlConnection.Open();   
            sqlCommand.Parameters.AddWithValue("CategoryName",categoryDTO.CategoryName);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            SqlConnection.Close();            
        }

        public List<CategoryDTO> GetAllCategories()
        {
            throw new NotImplementedException();
        }
    }
}