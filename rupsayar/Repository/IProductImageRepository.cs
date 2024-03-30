using rupsayar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace rupsayar.Repository
{
    public interface IProductImageRepository :IRepository<Tbl_ProductImages>
    {
        List<Tbl_ProductImages> GetProductImageByCondition(Expression<Func<Tbl_ProductImages, bool>> expression);
    }
}
