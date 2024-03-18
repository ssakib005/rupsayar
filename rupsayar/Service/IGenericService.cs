using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rupsayar.Service
{
    public interface IGenericService <TEntity> where TEntity : class
    {
        void Add(TEntity T);
        void Update(TEntity T);
        void Remove(TEntity T);
    }
}
