using ETicaret.Core.Base;
using ETicaret.Core.Abstract;
using ETicaret.Domain.Models;
using ETicaret.Domain.Context;
using System.Linq;
using System.Collections.Generic;

namespace ETicaret.Core.Concrete
{
    public class BasketRepository : BaseRepository<Basket> , IBasketRepository
    {
        public BasketRepository(ETicaretContext context) : base(context)
        {
        }

        public Basket GetBasketWithUniqueValue(int userId, int productId)
        {
            return Entity.Where(b => b.UserId == userId && b.ProductId == productId).FirstOrDefault();
        }

        public List<int> GetProductsId(int userid)
        {
            return Entity.Where(b => b.UserId == userid).Select(b => b.ProductId).ToList();
        }
    }
}
