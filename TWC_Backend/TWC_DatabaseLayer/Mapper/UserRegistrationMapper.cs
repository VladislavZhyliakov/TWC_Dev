using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer.DTOs;
using TWC_DatabaseLayer.Models;

namespace TWC_DatabaseLayer.Mapper
{
    public class UserRegistrationMapper : IMapper<User, UserRegistrationDTO>
    {
        public UserRegistrationDTO Map(User data)
        {
            return new UserRegistrationDTO
            {
                Username = data.Username,
                Email = data.Email,
                Password = data.Password.ToString(),
            };
        }

        public User Unmap(UserRegistrationDTO data)
        {
            return new User
            {
                Username = data.Username,
                Email = data.Email,
                Password = "", //perhaps a hash function should be called here
            };
        }
    }
}
