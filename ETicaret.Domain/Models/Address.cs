using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaret.Domain.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Country { get; set; } 
        public string City { get; set; } 
        public string District { get; set; } 
        public string Street { get; set; } 
        public string DoorNumber { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
