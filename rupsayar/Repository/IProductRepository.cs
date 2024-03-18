using rupsayar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace rupsayar.Repository
{
    public interface IProductRepository : IRepository<Tbl_Product>
    {
        List<Tbl_Product> GetProductsByCondition(Expression<Func<Tbl_Product, bool>> expression);
    }
}
