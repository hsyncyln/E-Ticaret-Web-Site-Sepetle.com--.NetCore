using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ETicaret.Domain.Models
{
    public class Supplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Product> Products { get; set; }

        public Supplier()
        {
            Products = new List<Product>();
        }
    }
}
