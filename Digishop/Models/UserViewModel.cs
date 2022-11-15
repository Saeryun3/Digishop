using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Digishop.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        [Required]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DisplayName("Wachtwoord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        [Required]
        [DisplayName("Voornaam")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Achternaam")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public UserViewModel()
        {

        }
    }
}
