using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rupsayar.Models.VM
{
    public class Tbl_Product_VM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Tbl_CategoryId { get; set; }
        public Tbl_Category Tbl_Category { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public virtual List<Tbl_ProductVariant> Tbl_ProductVariants { get; set; }
        public bool IsNewArrival { get; set; }
        public virtual List<Tbl_ProductRate> Tbl_ProductRates { get; set; }
        public virtual List<Tbl_ProductImages> Tbl_ProductImages { get; set; }
        public virtual List<Tbl_Product> RelatedProducts { get; set; }
        public bool IsActive { get; set; }
    }
}