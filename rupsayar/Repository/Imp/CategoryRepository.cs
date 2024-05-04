using rupsayar.Models;
using rupsayar.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace rupsayar.Repository.Imp
{
    public class CategoryRepository: Repository<Tbl_Category>, ICategoryRepository
    {
        internal CategoryRepository(ApplicationDbContext context)
          : base(context)
        {
        }
        public List<Tbl_Category> GetCategoryByCondition(Expression<Func<Tbl_Category, bool>> expression) 
        {
            return Set.Where(expression).ToList();
        }
        public List<Tbl_Category> GetCategoryByConditionWithPagination(Expression<Func<Tbl_Category, bool>> expression, PagedListVM pagedListVM, out int totalCount)
        {
            totalCount = Set.Where(expression).Count();
            return Set.Where(expression).OrderByDescending(x => x.Id).Skip(pagedListVM.ItemsPerPage * (pagedListVM.Page - 1)).Take(pagedListVM.ItemsPerPage).ToList();
        }
    }
}