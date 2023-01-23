using WebshopLogic;

namespace Digishop.Models
{
    public class HomeViewModel
    {
        // Viewmodel??
         public List<Category> categories = new List<Category>();
         public List<Product> products = new List<Product>();
        public bool signedIn { get; set; }  
        public bool? showOrderPlacedBox { get; set; }
        public bool admin { get; set; }
    }
}
