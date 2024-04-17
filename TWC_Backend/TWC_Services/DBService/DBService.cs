using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer;
using TWC_DatabaseLayer.Models;

namespace TWC_Services.DBService
{
    public class DBService : IDBService
    {
        private DataContext _context;

        public DBService(DataContext context) {  _context = context; }

        public async Task<List<User>> GetAllUsers()
        {
            return (await _context.Users.ToListAsync());
        }

        public async Task<User> GetUserById(int id)
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
        public async Task<User> GetUserByEmail(string email)
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

        public async Task<User> AddUser(User user)
        {
            try
            {
                //var checkUser = await GetUserByEmail(user.Email);
                if ((await GetUserByEmail(user.Email)) != null)
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

        public async Task DeleteUser(int id)
        {
            try
            {
                var user = await GetUserById(id);
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
