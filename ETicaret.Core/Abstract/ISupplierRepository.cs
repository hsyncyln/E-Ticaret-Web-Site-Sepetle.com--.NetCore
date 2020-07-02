using ETicaret.Domain.Models;
using ETicaret.Core.Base;

namespace ETicaret.Core.Abstract
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        int GetSupplierIdWithUniqueValue(int userid);
    }
}
