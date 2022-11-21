using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopDAL
{
    public class ProductDAL : IProductContainer
    {
        SqlConnection SqlConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi479257_webshopdtb;User Id=dbi479257_webshopdtb;Password=Dagal555");


        public void CreateProduct(ProductDTO productDTO)
        {
            // query create category
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Product(CategoryID, ProductName, ProductPrice, ProductDescription, ProductImage) VALUES (@CategoryID, @ProductName, @ProductPrice, @ProductDescription, @ProductImage)", SqlConnection);
            try
            {
                SqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CategoryID", productDTO.CategoryID);
                sqlCommand.Parameters.AddWithValue("@ProductName", productDTO.ProductName);
                sqlCommand.Parameters.AddWithValue("@ProductDescription", productDTO.ProductDescription);
                sqlCommand.Parameters.AddWithValue("@ProductPrice", productDTO.ProductPrice);
                sqlCommand.Parameters.AddWithValue("@ProductImage", productDTO.ProductImage);
                // Execute sqlquery return amount rows effected
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
        }
        public List<ProductDTO> GetAllProducts()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Product", SqlConnection);
            SqlConnection.Open();
            List<ProductDTO> Result = new List<ProductDTO>();
            try
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Result.Add(new ProductDTO()
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = (string)reader["ProductName"],
                        ProductPrice = (double)reader["ProductPrice"],
                        ProductDescription = (string)reader["ProductDescription"],
                        ProductImage = (string)reader["ProductImage"],
                        CategoryID = (int)reader["CategoryID"],
                    });
                }
                reader.Close();
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
        public List<ProductDTO> GetTop8product()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT TOP 8 * FROM Product", SqlConnection);
            SqlConnection.Open();
            List<ProductDTO> Result = new List<ProductDTO>();
            try
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Result.Add(new ProductDTO()
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = (string)reader["ProductName"],
                        ProductPrice = (double)reader["ProductPrice"],
                        ProductDescription = (string)reader["ProductDescription"],
                        ProductImage = (string)reader["ProductImage"],
                        CategoryID = (int)reader["CategoryID"],
                    });
                }
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
        public DateTime ArchiveProduct(int productID, DateTime dateTime)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Product SET Delete = @dateTime WHERE ProductID = @ProductID", SqlConnection);
            SqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("Delete", dateTime);
            sqlCommand.Parameters.AddWithValue("ProductID", productID);
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
            return dateTime;
        }

        public bool ExistProduct(string productName)
        {
            bool output = false;
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Product WHERE ProductName = @ProductName", SqlConnection);
            sqlCommand.Parameters.AddWithValue("ProductName", productName);
            try
            {
                SqlConnection.Open();
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

        public List<ProductDTO> GetAllProductsByCategoryID(int categoryID)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Product WHERE CategoryID = @CategoryID", SqlConnection);
            sqlCommand.Parameters.AddWithValue("CategoryID", categoryID);
            List<ProductDTO> products = new List<ProductDTO>();
            SqlConnection.Open();
            try
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new ProductDTO()
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = (string)reader["ProductName"],
                        ProductPrice = (double)reader["ProductPrice"],
                        ProductDescription = (string)reader["ProductDescription"],
                        ProductImage = (string)reader["ProductImage"],
                        CategoryID = (int)reader["CategoryID"]
                    });
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
            return products;
        }


        //public void DeleteProduct(int productID)
        //{
        //    SqlCommand sqlCommand = new SqlCommand("DELETE FROM Product WHERE ProductID = @ProductID", SqlConnection);
        //    SqlConnection.Open();
        //    sqlCommand.Parameters.AddWithValue("ProductID", productID);
        //    try
        //    {
        //        sqlCommand.ExecuteNonQuery();
        //    }
        //    catch (Exception exception)
        //    {
        //        Console.WriteLine(exception);
        //    }
        //    finally
        //    {
        //        SqlConnection.Close();
        //    }
        //}
    }
}
