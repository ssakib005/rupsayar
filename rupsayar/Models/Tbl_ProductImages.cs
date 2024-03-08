using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rupsayar.Models
{
    public class Tbl_ProductImages: Tbl_Base
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long Tbl_ProductId { get; set; }
        public Tbl_Product Tbl_Product { get; set; }
    }
}