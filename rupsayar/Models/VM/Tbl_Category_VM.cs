using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rupsayar.Models.VM
{
    public class Tbl_Category_VM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}