using SCRP.Foundation.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SCRP.Foundation.DataAccess.EntityFramework
{
    public abstract class EFRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : class, IEntity, new()

    {
        TContext _context = SingletonContext<TContext>.GetInstance();
        public int Add(TEntity entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Added;
            return _context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            var deleteEntity = _context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            return _context.SaveChanges();
        }

        //public int Update(TEntity entity)
        //{
        //    var updateEntity = _context.Entry(entity);
        //    updateEntity.State = EntityState.Modified;
        //    return _context.SaveChanges();
        //}

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().AsNoTracking().Where(filter).SingleOrDefault();
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return _context.Set<TEntity>().AsNoTracking().ToList();
            }
            else
            {
                return _context.Set<TEntity>().AsNoTracking().Where(filter).ToList();
            }
        }
    }
}
