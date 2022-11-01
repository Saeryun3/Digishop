using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopLogic.Helper
{
    public static class UserConvertor
    {
        public static UserDTO UserToDTO(User user)
        {
            return new UserDTO(user.UserID, user.Email, user.Password, user.IsAdmin, user.FirstName, user.LastName, user.PhoneNumber, user.Address, user.HouseNumber, user.PostalCode, user.City);
        }
    }
}
