using rupsayar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace rupsayar.Service
{
    public interface IProductImageService : IGenericService<Tbl_ProductImages>
    {
        List<Tbl_ProductImages> GetProductImageByCondition(Expression<Func<Tbl_ProductImages, bool>> expression);
    }
}