using ETicaret.Core.Base;
using ETicaret.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Core.Abstract
{
    public interface IBillRepository : IRepository<Bill>
    {
        List<Bill> GetBills(int userId);
    }
}
