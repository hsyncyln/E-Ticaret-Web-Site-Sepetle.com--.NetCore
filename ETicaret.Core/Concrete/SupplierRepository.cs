using ETicaret.Core.Base;
using ETicaret.Core.Abstract;
using ETicaret.Domain.Models;
using ETicaret.Domain.Context;
using System.Linq;

namespace ETicaret.Core.Concrete
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ETicaretContext context) : base(context)
        {
            
        }

        public int GetSupplierIdWithUniqueValue(int userid)
        {
            var user = Entity.Where(s => s.UserId == userid).FirstOrDefault();

            if (user == null) return 0;
            else return user.Id;
        }
    }
}
