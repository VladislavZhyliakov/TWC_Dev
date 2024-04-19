using Microsoft.EntityFrameworkCore;
using TWC_DatabaseLayer;
using TWC_DatabaseLayer.Models;

namespace TWC_Services.DBService
{
    public class DBService : IDBService
    {
        private DataContext _context;

        public DBService(DataContext context) {  _context = context; }

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
                if ((await GetUserByEmailAsync(user.Email)) != null)
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

        public async Task<PasswordSalt> AddSaltAsync(PasswordSalt salt)
        {
            try
            {
                if ((await GetSaltByUserIdAsync(salt.UserId)) != null)
                {
                    throw new Exception($"salt for this userId = {salt.UserId} exist");
                }
                await _context.PasswordSalts.AddAsync(salt);
                await _context.SaveChangesAsync();
                return salt;
            }
            
            catch (Exception ex)
            {
                throw new Exception($"cant add {typeof(PasswordSalt).Name}. Messege error: " + ex.Message);
            }
        }
        public async Task<PasswordSalt> GetSaltByUserIdAsync(int userId)
        {
            try
            {
                return await _context.PasswordSalts.SingleOrDefaultAsync(s => s.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"cant found {typeof(PasswordSalt).Name} by userId = {userId}. Messege error: " + ex.Message);
            }
        }

        public async Task<PasswordSalt> GetSaltByIdAsync(int id)
        {
            try
            {
                return await _context.PasswordSalts.SingleOrDefaultAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"cant found {typeof(PasswordSalt).Name} by Id = {id}. Messege error: " + ex.Message);
            }
        }

        public async Task<PasswordSalt> EditSaltAsync(PasswordSalt salt)
        {
            try
            {
                var oldSalt = await GetSaltByIdAsync(salt.Id);
                if (oldSalt == null) 
                { 
                    throw new Exception($"there is no salt with this id = {salt.Id}"); 
                }
                oldSalt.Salt = salt.Salt;
                oldSalt.UserId = salt.UserId;

                await _context.SaveChangesAsync();
                return oldSalt;
            }
            catch(Exception ex) 
            {
                throw new Exception($"cant edit {typeof(PasswordSalt).Name}. Messege error: " + ex.Message);
            }
        }

        public async Task DeleteSaltByIdAsync(int id)
        {
            try
            {
                var salt = await GetSaltByIdAsync(id);
                if (salt == null)
                    throw new Exception($"salt with id = {salt.Id} not exist");

                _context.PasswordSalts.Remove(salt);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"cant delete {typeof(PasswordSalt).Name}. Messege error: " + ex.Message);
            }
        }
    }
}
