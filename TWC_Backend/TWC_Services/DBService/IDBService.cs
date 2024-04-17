using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer.Models;

namespace TWC_Services.DBService
{
    public interface IDBService
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByEmail(string email);
        public Task<User> AddUser(User user);
        public Task DeleteUser(int id);
    }
}
