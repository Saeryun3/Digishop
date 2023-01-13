using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopInterface
{
    public interface IUserContainer
    {
        bool CreateUser(UserDTO userDTO);
        bool UserExist(UserDTO userDTO);
        bool UpdateUserAddress(UserDTO userDTO);
        bool UserExistsByEmailAndPassword(string email, string password);
        UserDTO GetUserByEmailAndPassword(UserDTO userDTO);
    }
}
