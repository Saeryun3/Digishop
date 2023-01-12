using System.Data.SqlClient;
using WebshopInterface;

namespace WebshopDAL
{
    public class OrderProductDAL : IOrderProductContainer
    {
        SqlConnection SqlConnection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi479257_webshopdtb;User Id=dbi479257_webshopdtb;Password=Dagal555");

        public ProductDTO GetProduct(int productID)
        {
            throw new NotImplementedException();
        }
    }
}

