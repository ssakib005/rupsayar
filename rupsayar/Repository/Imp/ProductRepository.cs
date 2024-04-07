using rupsayar.Models;
using rupsayar.Models.VM;
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
        public List<Tbl_Product> GetProductsByConditionWithPagination(Expression<Func<Tbl_Product, bool>> expression, PagedListVM pagedListVM, out int totalCount)
        {
            totalCount = Set.Where(expression).Count();
            return Set.Include("Tbl_Category").Where(expression).OrderByDescending(x => x.Id).Skip(pagedListVM.ItemsPerPage * (pagedListVM.Page - 1)).Take(pagedListVM.ItemsPerPage).ToList();
        }
    }
}