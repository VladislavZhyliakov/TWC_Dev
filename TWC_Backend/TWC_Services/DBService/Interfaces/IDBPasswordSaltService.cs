﻿using TWC_DatabaseLayer.Models;

namespace TWC_Services.DBService.Interfaces
{
    public interface IDBPasswordSaltService
    {
        public Task<PasswordSalt> AddSaltAsync(PasswordSalt salt);
        public Task<PasswordSalt> GetSaltByUserIdAsync(int userId);
        public Task<PasswordSalt> GetSaltByIdAsync(int id);
        public Task<PasswordSalt> EditSaltAsync(PasswordSalt salt);
        public Task DeleteSaltByIdAsync(int id);
    }
}
