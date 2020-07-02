using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Common.DTO
{
    public class BillModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Address { get; set; }
        public int Quentity { get; set; }
        public double Price { get; set; }
    }
}
