﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;
using WebshopIntertface;

namespace WebshopDAL
{
    public class ProductDAL : IProductContainer
    {
       SqlConnection SqlConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi479257;User Id=dbi479257;Password=Dagal555;");


        public void CreateProduct(ProductDTO productDTO)
        {
            // query create category
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Product(ProductName, ProductDescription, ProductPrice, ProductImage) VALUES (@ProductName, ProductDescription, ProductPrice, ProductImage)", SqlConnection);
            SqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("ProductName", productDTO.ProductName);
            sqlCommand.Parameters.AddWithValue("ProductDescription", productDTO.ProductDescription);
            sqlCommand.Parameters.AddWithValue("ProductPrice", productDTO.ProductPrice);
            sqlCommand.Parameters.AddWithValue("ProductImage", productDTO.ProductImage);
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
        }
        public List<ProductDTO> GetAllProduct()
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
                        Delete = (DateTime)reader["Delete"],
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

        public void DeleteProduct(int productID)
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Product WHERE ProductID = @ProductID", SqlConnection);
            SqlConnection.Open();
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
        }
    }
}
