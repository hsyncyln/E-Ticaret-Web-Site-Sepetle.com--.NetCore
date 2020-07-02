using ETicaret.Common.DTO;
using System.Collections.Generic;

namespace ETicaret.Web.Models
{
    public class MainModel
    {

        public UserModel User { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
        public IEnumerable<ProductModel> Basket { get; set; }
    }
}
