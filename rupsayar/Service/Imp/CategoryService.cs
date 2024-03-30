using rupsayar.Models;
using rupsayar.Repository;
using rupsayar.Repository.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace rupsayar.Service.Imp
{
    public class CategoryService: ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository _categoryRepository;
        public CategoryService()
        {
            _context = new ApplicationDbContext();
            _categoryRepository = new CategoryRepository(_context);
        }
        public List<Tbl_Category> GetCategoryByCondition(Expression<Func<Tbl_Category, bool>> expression) 
        {
            return _categoryRepository.GetCategoryByCondition(expression).ToList();
        }
    }
}