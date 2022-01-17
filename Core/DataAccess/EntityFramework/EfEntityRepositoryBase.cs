using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntitiyFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext recapContext = new TContext())
            {
                var addedEntity = recapContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                recapContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext recapContext = new TContext())
            {
                var deletedEntity = recapContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                recapContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext recapContext = new TContext())
            {
                return recapContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext recapContext = new TContext())
            {
                return filter == null ? recapContext.Set<TEntity>().ToList() 
                                      : recapContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext recapContext = new TContext())
            {
                var updatedEntity = recapContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                recapContext.SaveChanges();
            }
        }
    }
}
