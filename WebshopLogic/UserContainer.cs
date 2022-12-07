using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;
using WebshopLogic.Helper;

namespace WebshopLogic
{
    public class UserContainer
    {
        private IUserContainer _iuserContainer;
        public UserContainer (IUserContainer iuser)
        {
            _iuserContainer = iuser;
        }
        public bool CreateUser(User user)
        {

            if (!UserExist(user))
            {
                UserDTO userDTO = UserConvertor.UserToDTO(user);
                _iuserContainer.CreateUser(userDTO);
                return true;
            }
            return false;
        }
        public bool UserExist(User user)
        {
            UserDTO userDTO = UserConvertor.UserToDTO(user);
            return _iuserContainer.UserExist(userDTO);
        }

        public bool UserExistsByEmailAndPassword(User user)
        {
            return _iuserContainer.UserExistsByEmailAndPassword(user.Email, user.Password);
        }
        public User GetUserByEmailAndPassword(User user)
        {
            UserDTO userDTO = UserConvertor.UserToDTO(user);
            return new User(_iuserContainer.GetUserByEmailAndPassword(userDTO));
        }
        // add adresgegevens 


        //public User GetUser(User user)
        //{
        //    return new User(_iuserContainer.GetUser(user.Email, user.Password));//GetUserByEmailAndPassword(user.Email, user.Password));
        //}
    }
}
