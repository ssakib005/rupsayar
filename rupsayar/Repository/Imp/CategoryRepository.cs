﻿using rupsayar.Models;
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
    }
}