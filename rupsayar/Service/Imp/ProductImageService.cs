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
    public class ProductImageService : IProductImageService
    {
        private readonly ApplicationDbContext _context;
        public IProductImageRepository _productImageRepository;
        public ProductImageService()
        {
            _context = new ApplicationDbContext();
            _productImageRepository = new ProductImageRepository(_context);
        }
        public List<Tbl_ProductImages> GetProductImageByCondition(Expression<Func<Tbl_ProductImages, bool>> expression) 
        {
            return _productImageRepository.GetProductImageByCondition(expression).ToList();
        }
        public void Add(Tbl_ProductImages T)
        {
            if (T == null)
                throw new ArgumentNullException("Tbl_ProductImages");
            try
            {
                _productImageRepository.Add(T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(Tbl_ProductImages T)
        {
            if (T == null)
                throw new ArgumentNullException("Tbl_ProductImages");
            try
            {
                _productImageRepository.Update(T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Remove(Tbl_ProductImages T)
        {
            if (T == null)
                throw new ArgumentNullException("Tbl_ProductImages");
            try
            {
                _productImageRepository.Remove(T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}