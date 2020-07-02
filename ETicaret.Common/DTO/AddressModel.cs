using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.Common.DTO
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string DoorNumber { get; set; }

        public string FullAddress { get { return this.District + " Mah. " + this.Street + " Sk. Door Number:" + this.DoorNumber + " " + this.City + "/" + this.Country; } }

    }
}
