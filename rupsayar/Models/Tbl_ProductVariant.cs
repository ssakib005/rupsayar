using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rupsayar.Models
{
    public class Tbl_ProductVariant : Tbl_Base
    {
        public Tbl_Product Tbl_Product { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}