using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWC_Services.TokenService
{
    public interface ITokenService
    {
        string CreateToken(int userId, string userEmail, string role);
    }
}
