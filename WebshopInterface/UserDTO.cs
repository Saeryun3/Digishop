using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopInterface
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public UserDTO(int userID, string email, string password, bool isAdmin, string firstName, string lastName, string phoneNumber, string address, string houseNumber, string postalCode, string city)
        {
            UserID = userID;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            City = city;
        }
        public UserDTO()
        {

        }
    }
}
