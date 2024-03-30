using rupsayar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace rupsayar.Repository.Imp
{
    public class ProductImageRepository: Repository<Tbl_ProductImages>, IProductImageRepository
    {
        internal ProductImageRepository(ApplicationDbContext context)
          : base(context)
        {
        }
        public List<Tbl_ProductImages> GetProductImageByCondition(Expression<Func<Tbl_ProductImages, bool>> expression) 
        {
            return Set.Where(expression).ToList();
        }
    }
}