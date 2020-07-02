using System;
using System.Collections.Generic;
using System.Text;
using ETicaret.Domain.Models;
using ETicaret.Core.Base;

namespace ETicaret.Core.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        int GetUserIdWithUniqueValue(string email,string password);
        int GetAddressIdWithUniqueValue(int userid);

    }
}
