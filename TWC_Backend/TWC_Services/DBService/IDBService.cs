using TWC_DatabaseLayer.Models;

namespace TWC_Services.DBService
{
    public interface IDBService
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> AddUserAsync(User user);
        public Task DeleteUserAsync(int id);
        public Task<PasswordSalt> AddSaltAsync(PasswordSalt salt);
        public Task<PasswordSalt> GetSaltByUserIdAsync(int userId);
        public Task<PasswordSalt> GetSaltByIdAsync(int id);
        public Task<PasswordSalt> EditSaltAsync(PasswordSalt salt);
        public Task DeleteSaltByIdAsync(int id);

    }
}
