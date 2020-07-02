using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.Common.DTO
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber{ get; set; }


    }
}
