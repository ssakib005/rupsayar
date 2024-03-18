using rupsayar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace rupsayar.Repository.Imp
{
    public class ProductRepository : Repository<Tbl_Product>, IProductRepository
    {
        internal ProductRepository(ApplicationDbContext context)
          : base(context)
        {
        }
        public List<Tbl_Product> GetProductsByCondition(Expression<Func<Tbl_Product, bool>> expression) 
        {
            return Set.Where(expression).ToList();
        }
    }
}