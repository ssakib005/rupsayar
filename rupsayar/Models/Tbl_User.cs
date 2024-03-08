using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rupsayar.Models
{
    public class Tbl_User : Tbl_Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HashPassword { get; set; }
        public string Division { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
    }
}