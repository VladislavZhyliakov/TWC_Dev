using TWC_DatabaseLayer.Models;

namespace TWC_Services.DBService.Interfaces
{
    public interface IDBUserService
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> AddUserAsync(User user);
        public Task DeleteUserAsync(int id);
    }
}
