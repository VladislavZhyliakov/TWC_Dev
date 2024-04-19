using Microsoft.EntityFrameworkCore;
using TWC_DatabaseLayer;
using TWC_DatabaseLayer.Models;
using TWC_Services.DBService.Interfaces;

namespace TWC_Services.DBService.Services
{
    public class DBPasswordSaltService : IDBPasswordSaltService
    {
        private DataContext _context;

        public DBPasswordSaltService(DataContext context) { _context = context; }

        public async Task<PasswordSalt> AddSaltAsync(PasswordSalt salt)
        {
            try
            {
                if (await GetSaltByUserIdAsync(salt.UserId) != null)
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
            catch (Exception ex)
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
