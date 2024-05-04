using rupsayar.Models;
using rupsayar.Models.VM;
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
        public void Add(Tbl_Category T)
        {
            if (T == null)
                throw new ArgumentNullException("Tbl_Category");
            try
            {
                _categoryRepository.Add(T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(Tbl_Category T)
        {
            if (T == null)
                throw new ArgumentNullException("Tbl_Category");
            try
            {
                _categoryRepository.Update(T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Remove(Tbl_Category T)
        {
            if (T == null)
                throw new ArgumentNullException("Tbl_Category");
            try
            {
                _categoryRepository.Remove(T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tbl_Category> GetCategoryByCondition(Expression<Func<Tbl_Category, bool>> expression) 
        {
            return _categoryRepository.GetCategoryByCondition(expression).ToList();
        }
        public List<Tbl_Category> GetCategoryByConditionWithPagination(Expression<Func<Tbl_Category, bool>> expression, PagedListVM pagedListVM, out int totalCount)
        {
            return _categoryRepository.GetCategoryByConditionWithPagination(expression, pagedListVM, out totalCount).ToList();
        }
    }
}