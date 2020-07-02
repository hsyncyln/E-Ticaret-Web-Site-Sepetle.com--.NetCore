using ETicaret.Core.Abstract;
using ETicaret.Core.Base;
using ETicaret.Domain.Context;
using ETicaret.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETicaret.Core.Concrete
{
    public class BillRepository : BaseRepository<Bill> , IBillRepository
    {
        public BillRepository(ETicaretContext context) : base(context)
        {

        }

        public List<Bill> GetBills(int userId)
        {
            return Entity.Where(b => b.UserId == userId).ToList();
        }
    }
}
