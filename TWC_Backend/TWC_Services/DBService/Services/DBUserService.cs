using Microsoft.EntityFrameworkCore;
using TWC_DatabaseLayer;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService.Interfaces;

namespace TWC_Services.DBService.Services
{
    public class DBUserService : IDBUserService
    {
        private DataContext _context;

        public DBUserService(DataContext context) { _context = context; }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"cant found {typeof(User).Name} by id. Messege error: " + ex.Message);
            }
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"cant found {typeof(User).Name} by email. Messege error: " + ex.Message);
            }
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                if (await GetUserByEmailAsync(user.Email) != null)
                {
                    throw new Exception($"user with email = {user.Email} exist");
                }

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"cant add {typeof(User).Name}. Messege error: " + ex.Message);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var user = await GetUserByIdAsync(id);
                if (user == null)
                    throw new Exception($"user with id = {user.Id} not exist");

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"cant delete {typeof(User).Name}. Messege error: " + ex.Message);
            }
        }
    }
}
