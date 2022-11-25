using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopInterface;

namespace WebshopTest
{
    public class UserContainerTestStub : IUserContainer
    {
        public List<UserDTO> users = new List<UserDTO>();
        public UserContainerTestStub()
        {
            UserDTO user1 = new UserDTO()
            {
                UserID = 1,
                Email = "Sam@hotmail.com",
                Password = "1234",
                IsAdmin = false,
                FirstName = "Sam",
                LastName = "Dag",
                PhoneNumber = 0644335690,
                Address = "steenmanslaan",
                HouseNumber = "10A",
                PostalCode = "4030AB",
                City = "Eindhoven",
            };
            UserDTO user2 = new UserDTO()
            {
                UserID = 1,
                Email = "Sam@hotmail.com",
                Password = "1234",
                IsAdmin = false,
                FirstName = "Sam",
                LastName = "Dag",
                PhoneNumber = 0644335690,
                Address = "steenmanslaan",
                HouseNumber = "10A",
                PostalCode = "4030AB",
                City = "Eindhoven",
            };
            users.Add(user1);
            users.Add(user2);
        }

        public bool CreateUser(UserDTO userDTO)
        {
            users.Add(userDTO);
            return true;
        }

        public UserDTO GetUserByEmailAndPassword(UserDTO userDTO)
        {
            foreach (UserDTO userDTOs in users)
            {
                if (userDTO.Email == userDTO.Email && userDTO.Password == userDTO.Password)
                {
                    return userDTO;
                }
            }
            return null;
        }

        public bool UserExist(UserDTO userDTO)
        {
            foreach (UserDTO user in users)
            {
                if (user.Email == userDTO.Email)
                    return true;
            }
            return false;
        }

        public bool UserExistsByEmailAndPassword(string email, string password)
        {
            foreach (UserDTO user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
