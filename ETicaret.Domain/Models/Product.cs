using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaret.Domain.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StockQuentity { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public string CategoryName { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
