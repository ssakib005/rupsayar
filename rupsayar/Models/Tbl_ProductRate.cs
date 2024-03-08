using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rupsayar.Models
{
    public class Tbl_ProductRate: Tbl_Base
    {
        public Tbl_User User { get; set; }
        public float Rate { get; set; }
        public Tbl_Product Product { get; set; }
        public string Review { get; set; }
    }
}