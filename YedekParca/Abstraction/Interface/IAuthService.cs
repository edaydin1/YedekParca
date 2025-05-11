using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Interface
{
    public interface IAuthService
    {
        string GenerateJwtToken(Users user);
        Users ValidateUser(string username, string password);
    }
}
