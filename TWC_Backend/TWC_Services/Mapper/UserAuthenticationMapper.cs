using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer.DTOs;
using TWC_DatabaseLayer.Models;

namespace TWC_Services.Mapper
{
    public class UserAuthenticationMapper : IMapper<User, UserAuthenticationDTO>
    {
        public UserAuthenticationDTO Map(User data)
        {
            return new UserAuthenticationDTO
            {
                Email = data.Email,
                Password = data.Password.ToString(),
            };
        }

        public User Unmap(UserAuthenticationDTO data)
        {
            return new User
            {
                Email = data.Email,
                Password = data.Password, //perhaps a hash function should be called here
            };
        }
    }
}
