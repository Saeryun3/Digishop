using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopDAL
{
    public class ReviewDAL : IReviewContainer
    {
        SqlConnection SqlConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi479257_webshopdtb;User Id=dbi479257_webshopdtb;Password=Dagal555");

        public bool CreateReview(ReviewDTO reviewDTO)
        {
            SqlConnection.Open();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO [Review](UserID, ProductID, Title, Text, Rating, Created VALUES (@UserID, @ProductID, @Title, @Text, @Rating, @Created) )",SqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserID", reviewDTO.UserID);
                sqlCommand.Parameters.AddWithValue("@ProductID", reviewDTO.ProductID);
                sqlCommand.Parameters.AddWithValue("@Title", reviewDTO.Title);
                sqlCommand.Parameters.AddWithValue("@Text", reviewDTO.Text);
                sqlCommand.Parameters.AddWithValue("@Rating", reviewDTO.Rating);
                sqlCommand.Parameters.AddWithValue("@Created", reviewDTO.Created);
                sqlCommand.ExecuteNonQuery();
                return true;
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
        }

        public int GetAllReviewsForProduct(int productID)
        {
            SqlConnection.Open();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Review WHERE ProductID = @ProductID", SqlConnection);
                sqlCommand.Parameters.AddWithValue("ProductID", productID);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    productID = (int)reader["ProductID"];
                }
                return productID;
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
        }

        /*
         *       SqlConnection.Open();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("",SqlConnection);

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
         */
    }
}
