using ETicaret.Core.Base;
using ETicaret.Core.Abstract;
using ETicaret.Domain.Models;
using ETicaret.Domain.Context;
using System.Linq;

namespace ETicaret.Core.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ETicaretContext context) : base(context)
        {
        }

        public int GetAddressIdWithUniqueValue(int userid)
        {
            return Entity.Find(userid).AddressId;
        }

        public int GetUserIdWithUniqueValue(string email, string password)
        {
            try
            {
                return Entity.Where(u => u.EMail == email && u.Password == password).FirstOrDefault().Id;
            }
            catch
            {
                return 0;
            }
           
        }
    }
}
