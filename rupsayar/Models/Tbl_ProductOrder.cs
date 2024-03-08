using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rupsayar.Models
{
    public class Tbl_ProductOrder : Tbl_Base
    {
        public Tbl_Product Tbl_Product { get; set; }
        public int RequiredQuantity { get; set; }
        public Tbl_User Tbl_User { get; set; }
        public float Amount { get; set; }
        public bool IsOrderPlace { get; set; }
    }
}