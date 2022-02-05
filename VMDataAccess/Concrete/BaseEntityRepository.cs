using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VMDataAccess.Abstract;
using VMEntities;

namespace VMDataAccess.Concrete
{
    public class BaseEntityRepository<TEntity, TContext> : IBaseEntityRepository<TEntity>
       where TEntity : BaseEntity, new()
       where TContext : DbContext, new()
    {
        public async Task Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                entity.Active = true;
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                entity.Active = false;
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
