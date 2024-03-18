using rupsayar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace rupsayar.Repository.Imp
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext _context;
        private DbSet<TEntity> _set;
        internal Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        protected DbSet<TEntity> Set
        {
            get { return _set ?? (_set = _context.Set<TEntity>()); }
        }
        protected ApplicationDbContext GetContext
        {
            get { return _context; }
        }
        public void Add(TEntity entity)
        {
            try
            {
                ITbl_Base data = (ITbl_Base)entity;
                data.CreatedAt = DateTime.Now;
                data.ModifyAt = DateTime.Now;
                data.CreatedBy = HttpContext.Current.User.Identity.Name;
                data.ModifyBy = HttpContext.Current.User.Identity.Name;

                Set.Add(entity);
            }
            catch (Exception e)
            {

            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                ITbl_Base data = (ITbl_Base)entity;

                data.ModifyAt = DateTime.Now;
                data.ModifyBy = HttpContext.Current.User.Identity.Name;
                if (data.CreatedAt == null)
                {
                    data.CreatedAt = DateTime.Now;
                    data.CreatedBy = data.ModifyBy;
                }

                var entry = _context.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    Set.Attach(entity);
                    entry = _context.Entry(entity);
                }
                entry.State = EntityState.Modified;
            }
            catch (Exception es)
            {

            }
        }
        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }
    }
}