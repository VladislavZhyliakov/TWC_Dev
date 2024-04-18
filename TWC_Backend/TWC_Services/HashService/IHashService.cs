using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWC_Services.HashService
{
    public interface IHashService
    {
        public string HashPassword(string password, out byte[] salt);
        public bool PasswordVerification(string password, string hash, byte[] salt);
    }
}
