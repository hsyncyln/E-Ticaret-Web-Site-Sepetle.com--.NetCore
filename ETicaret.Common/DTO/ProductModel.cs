using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.Common.DTO
{
    public class ProductModel
    {

        public int Id { get; set; }
        public int StockQuentity { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public string CategoryName { get; set; }

        public UserModel SupplyUser { get; set; }


    }
}
