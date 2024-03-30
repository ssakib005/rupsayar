using rupsayar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace rupsayar.Service
{
    public interface ICategoryService
    {
        List<Tbl_Category> GetCategoryByCondition(Expression<Func<Tbl_Category, bool>> expression);
    }
}