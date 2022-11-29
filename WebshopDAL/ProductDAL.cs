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
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Product(CategoryID, ProductName, ProductPrice, ProductDescription, ProductImage) VALUES (@CategoryID, @ProductName, @ProductPrice, @ProductDescription, @ProductImage)", SqlConnection);

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
            List<ProductDTO> Result = new List<ProductDTO>();
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Product", SqlConnection);
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
                        // als het niet null is pakt dan een waarde in database als wel null 1 jan 1970
                        Delete = reader["Delete"] != DBNull.Value ? (DateTime)reader["Delete"] : DateTime.MinValue
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
            //   var Result = GetAllProducts().TakeLast(8).ToList();

            List<ProductDTO> Result = new List<ProductDTO>();
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT TOP 8 * FROM Product WHERE [Delete] is NULL", SqlConnection);
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
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE Product SET [Delete] = @Delete WHERE ProductID = @ProductID", SqlConnection);

                sqlCommand.Parameters.AddWithValue("@Delete", dateTime);
                sqlCommand.Parameters.AddWithValue("@ProductID", productID);
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
        public ProductDTO GetProductID(int productID)
        {            
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Product] WHERE ProductID = @ProductID ", SqlConnection);
                sqlCommand.Parameters.AddWithValue("ProductID", productID);
              
                ProductDTO productdto = new ProductDTO();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if(reader.Read())   
                {

                    productdto.ProductID = (int)reader["ProductID"];
                    productdto.ProductName = (string)reader["ProductName"];
                    productdto.ProductPrice = (double)reader["ProductPrice"];
                    productdto.ProductDescription = (string)reader["ProductDescription"];
                    productdto.ProductImage = (string)reader["ProductImage"];
                    productdto.CategoryID = (int)reader["CategoryID"];
                    
                };
                reader.Close();
                return productdto;
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

        public bool ExistProduct(string productName)
        {
            bool output = false;
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Product WHERE ProductName = @ProductName", SqlConnection);
                sqlCommand.Parameters.AddWithValue("ProductName", productName);
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
            List<ProductDTO> products = new List<ProductDTO>();
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Product WHERE CategoryID = @CategoryID", SqlConnection);
                sqlCommand.Parameters.AddWithValue("CategoryID", categoryID);
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
