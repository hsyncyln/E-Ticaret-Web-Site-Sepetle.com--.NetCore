using System.Collections.Generic;
using ETicaret.Domain.Models;
using ETicaret.Core.Base;

namespace ETicaret.Core.Abstract
{
    public interface IBasketRepository : IRepository<Basket>
    {
        List<int> GetProductsId(int userid);
        Basket GetBasketWithUniqueValue(int userId, int productId);
    }
}
