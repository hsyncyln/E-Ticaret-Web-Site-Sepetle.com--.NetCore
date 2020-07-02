using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Domain.Models
{
    public class Bill
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }
        
        public string Address { get; set; }
        public double Price { get; set; }
        public int Quentity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
