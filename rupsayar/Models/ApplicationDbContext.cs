using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace rupsayar.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base("name=Rupsayar")
        {
            this.SetCommandTimeOut(180);
        }

        public void SetCommandTimeOut(int Timeout)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = Timeout;
        }

        public IDbSet<Tbl_User> Tbl_Users { get; set; }
        public IDbSet<Tbl_Category> Tbl_Categories { get; set; }
        public IDbSet<Tbl_Product> Tbl_Products { get; set; }
        public IDbSet<Tbl_ProductOrder> Tbl_ProductOrders { get; set; }
        public IDbSet<Tbl_ProductRate> Tbl_ProductRates { get; set; }
        public IDbSet<Tbl_ProductVariant> Tbl_ProductVariants { get; set; }
        public IDbSet<Tbl_ProductImages> Tbl_ProductImages { get; set; }
    }
}