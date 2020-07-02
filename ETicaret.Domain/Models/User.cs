using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ETicaret.Domain.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public List<Basket> Basket { get; set; }

        public User()
        {
            Basket = new List<Basket>();
        }
    }
}
