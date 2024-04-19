using TWC_DatabaseLayer.DTOs;
using TWC_DatabaseLayer.Models;


namespace TWC_Services.Mapper
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
                Password = data.Password,
            };
        }
    }
}
