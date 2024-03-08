using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rupsayar.Models
{
    public class Tbl_Category : Tbl_Base
    {
        public string CategoryName { get; set; }
        public virtual List<Tbl_Product> Tbl_Products { get; set; }
        public bool IsActive { get; set; }
    }
}