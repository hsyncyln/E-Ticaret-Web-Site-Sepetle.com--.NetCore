using ETicaret.Domain.Models;
using ETicaret.Core.Base;
using System.Collections.Generic;

namespace ETicaret.Core.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> SupplierProducts(int supplierId);

    }
}
