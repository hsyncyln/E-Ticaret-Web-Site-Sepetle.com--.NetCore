using ETicaret.Core.Base;
using ETicaret.Core.Abstract;
using ETicaret.Domain.Models;
using ETicaret.Domain.Context;
using System.Collections.Generic;
using System.Linq;

namespace ETicaret.Core.Concrete
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ETicaretContext context) : base(context)
        {
        }

        public IEnumerable<Product> SupplierProducts(int supplierId)
        {
            return Entity.Where(p => p.SupplierId == supplierId);
        }
    }
}
