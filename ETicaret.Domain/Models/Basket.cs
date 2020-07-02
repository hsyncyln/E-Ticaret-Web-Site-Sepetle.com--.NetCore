using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Domain.Models
{
    public class Basket
    {

        public int Id { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }

    }
}
