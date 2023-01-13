using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using WebshopInterface;
using WebshopLogic;

namespace Digishop.Models
{
    public class CartViewModel
    {
        public string CartID { get; set; }
        public List<OrderProduct> cartProducts{ get; set; }
        public OrderProduct orderProduct { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public CartViewModel()
        {
        }

    }
}
