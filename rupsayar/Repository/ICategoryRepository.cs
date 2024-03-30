﻿using rupsayar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace rupsayar.Repository
{
    public interface ICategoryRepository
    {
        List<Tbl_Category> GetCategoryByCondition(Expression<Func<Tbl_Category, bool>> expression);
    }
}
