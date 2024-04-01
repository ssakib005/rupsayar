using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rupsayar.Models.VM
{
    public class Tbl_Product_VM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public long Tbl_CategoryId { get; set; }
        public Tbl_Category Tbl_Category { get; set; }
        [Required(ErrorMessage = "Unit Price is required.")]
        public float UnitPrice { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
        public virtual List<Tbl_ProductVariant> Tbl_ProductVariants { get; set; }
        public bool IsNewArrival { get; set; }
        public virtual List<Tbl_ProductRate> Tbl_ProductRates { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public virtual List<HttpPostedFileBase> Tbl_ProductImageList { get; set; }
        public virtual List<Tbl_ProductImages> Tbl_ProductImages { get; set; }
        public virtual List<Tbl_Product> RelatedProducts { get; set; }
        public bool IsActive { get; set; }
    }
}