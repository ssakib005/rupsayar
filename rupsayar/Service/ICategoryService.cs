using rupsayar.Models;
using rupsayar.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace rupsayar.Service
{
    public interface ICategoryService: IGenericService<Tbl_Category>
    {
        List<Tbl_Category> GetCategoryByCondition(Expression<Func<Tbl_Category, bool>> expression);
        List<Tbl_Category> GetCategoryByConditionWithPagination(Expression<Func<Tbl_Category, bool>> expression, PagedListVM pagedListVM, out int totalCount);
    }
}