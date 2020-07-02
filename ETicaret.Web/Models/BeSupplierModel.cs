using ETicaret.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.Web.Models
{
    public class BeSupplierModel
    {
        public UserModel User { get; set; }
        public IEnumerable<ProductModel> Basket { get; set; }
    }
}
