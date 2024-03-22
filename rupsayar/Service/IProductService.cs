using rupsayar.Models;
using rupsayar.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace rupsayar.Service
{
    public interface IProductService : IGenericService<Tbl_Product>
    {
        List<Tbl_Product> GetProductsByCondition(Expression<Func<Tbl_Product, bool>> expression);
        List<Tbl_Product> GetProductsByConditionWithPagination(Expression<Func<Tbl_Product, bool>> expression, PagedListVM pagedListVM ,out int totalCount);
    }
}