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
    public class ProductService: IProductService
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository _productRepository;
        public ProductService() 
        {
            _context = new ApplicationDbContext();
            _productRepository = new ProductRepository(_context);
        }
        public List<Tbl_Product> GetProductsByCondition(Expression<Func<Tbl_Product, bool>> expression) 
        {
            return _productRepository.GetProductsByCondition(expression).ToList();
        }
        public List<Tbl_Product> GetProductsByConditionWithPagination(Expression<Func<Tbl_Product, bool>> expression, PagedListVM pagedListVM, out int totalCount) 
        {
            return _productRepository.GetProductsByConditionWithPagination(expression,pagedListVM, out totalCount).ToList();
        }
        public void Add(Tbl_Product T)
        {
            if (T == null)
                throw new ArgumentNullException("Tbl_Product");
            try
            {
                _productRepository.Add(T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(Tbl_Product T)
        {
            if (T == null)
                throw new ArgumentNullException("Tbl_Product");
            try
            {
                _productRepository.Update(T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Remove(Tbl_Product T)
        {
            if (T == null)
                throw new ArgumentNullException("Tbl_Product");
            try
            {
                _productRepository.Remove(T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}