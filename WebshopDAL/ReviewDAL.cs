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
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO [Review](UserID, ProductID, Title, Text, Created) VALUES (@UserID, @ProductID, @Title, @Text, @Created)", SqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserID", reviewDTO.UserID);
                sqlCommand.Parameters.AddWithValue("@ProductID", reviewDTO.ProductID);
                sqlCommand.Parameters.AddWithValue("@Title", reviewDTO.Title);
                sqlCommand.Parameters.AddWithValue("@Text", reviewDTO.Text);
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

        public List<ReviewDTO> GetAllReviewsForProduct(int productID)
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Review WHERE ProductID = @ProductID", SqlConnection);
                sqlCommand.Parameters.AddWithValue("ProductID", productID);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ReviewDTO reviewDTO = new ReviewDTO();
                    reviewDTO.ProductID = (int)reader["ProductID"];
                    reviewDTO.Title = (string)reader["Title"];
                    reviewDTO.Text = (string)reader["Text"];
                    reviewDTO.UserID = (int)reader["UserID"];
                    reviews.Add(reviewDTO);
                }
                reader.Close();
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
            return reviews;
        }
        public bool CheckIfUserHasProductReviewed(int productID, int userID)
        {
            bool output = false;
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Review WHERE ProductID = @ProductID AND UserID = @UserID ", SqlConnection);
                sqlCommand.Parameters.AddWithValue("ProductID", productID);
                sqlCommand.Parameters.AddWithValue("UserID", userID);
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
