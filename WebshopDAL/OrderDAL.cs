using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopDAL
{
    public class OrderDAL : IOrderContainer
    {
        SqlConnection SqlConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi479257_webshopdtb;User Id=dbi479257_webshopdtb;Password=Dagal555");

        public bool SetOrder()
        {
            throw new NotImplementedException();
        }

        public bool AddToCart(string CartID, int ProductID, int Amount, double UnitPrice)
        {
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO OrderProduct(ProductID, Amount, UnitPrice, CartID) VALUES (@ProductID, @Amount, @UnitPrice, @CartID)", SqlConnection);

                sqlCommand.Parameters.AddWithValue("@ProductID", ProductID);
                sqlCommand.Parameters.AddWithValue("@Amount", Amount);
                sqlCommand.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                sqlCommand.Parameters.AddWithValue("@CartID", CartID);
                // Execute sqlquery return amount rows effected
                sqlCommand.ExecuteNonQuery();
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

            return true;
        }

        public bool UpdateCart(string CartID, int ProductID, int Amount)
        {
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE OrderProduct SET Amount = Amount + @Amount WHERE CartID = @CartID AND ProductID = @ProductID", SqlConnection);
                sqlCommand.Parameters.AddWithValue("@CartID", CartID);
                sqlCommand.Parameters.AddWithValue("@ProductID", ProductID);
                sqlCommand.Parameters.AddWithValue("@Amount", Amount);
                sqlCommand.ExecuteNonQuery();

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
            return true;
        }

        public bool DeleteFromCart(string CartID, int ProductID)
        {
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM OrderProduct WHERE CartID = @CartID AND ProductID = @ProductID", SqlConnection);
                sqlCommand.Parameters.AddWithValue("@CartID", CartID);
                sqlCommand.Parameters.AddWithValue("@ProductID", ProductID);
                sqlCommand.ExecuteNonQuery();

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
            return true;
        }

        public bool PlaceOrder(int userID)
        {
            //plaats order
            string orderNumber = Guid.NewGuid().ToString();

            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO [Order](UserID, OrderDate, OrderNumber) VALUES (@userID, @orderDate, @orderNumber)", SqlConnection);
                sqlCommand.Parameters.AddWithValue("@userID", userID);
                sqlCommand.Parameters.AddWithValue("@orderDate", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@orderNumber", orderNumber);

                sqlCommand.ExecuteNonQuery();

                //verander shopID en cartId in tabel orderproducts
                SqlCommand sqlCommand2 = new SqlCommand("Update OrderProduct SET OrderID = @orderId AND CartID = @cartID", SqlConnection);
                sqlCommand.Parameters.AddWithValue("@orderId", GetOrderIDByUserIDAndOrderNumber(userID, orderNumber));
                sqlCommand.Parameters.AddWithValue("@cartID", null);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
            finally
            {
                SqlConnection.Close();
            }

            return true;


        }

        public int GetOrderIDByUserIDAndOrderNumber(int userID, string orderNumber)
        {
            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT (OrderID) FROM [Order] WHERE UserID = @userID AND OrderNumber = @orderNumber", SqlConnection);
                sqlCommand.Parameters.AddWithValue("@userID", userID);
                sqlCommand.Parameters.AddWithValue("@orderNumber", orderNumber);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    return (int)reader["OrderID"];
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

            return 0;

        }

        public List<OrderProductDTO> GetCartProducts(string CartID)
        {
            List<OrderProductDTO> orderProducts = new List<OrderProductDTO>();

            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM OrderProduct WHERE CartID = @CartID", SqlConnection);
                sqlCommand.Parameters.AddWithValue("CartID", CartID);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    orderProducts.Add(new OrderProductDTO(0, (int)reader["ProductID"], (int)reader["Amount"], (double)reader["UnitPrice"]));
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

            return orderProducts;
        }

        public OrderProductDTO GetCartProduct(string CartID, int ProductID)
        {
            OrderProductDTO cartProduct = new OrderProductDTO();

            try
            {
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM OrderProduct WHERE CartID = @CartID AND ProductID = @ProductID", SqlConnection);
                sqlCommand.Parameters.AddWithValue("@CartID", CartID);
                sqlCommand.Parameters.AddWithValue("@ProductID", ProductID);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    cartProduct.ProductID = (int)reader["ProductID"];
                    cartProduct.Amount = (int)reader["Amount"];
                    cartProduct.UnitPrice = (double)reader["UnitPrice"];
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

            return cartProduct;
        }

    }
}
