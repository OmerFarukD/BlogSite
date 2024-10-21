using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Core.Repositories;

public class EfRepositoryBase<TContext, TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
    where TContext : DbContext
{

    protected TContext Context { get; }

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }
    public TEntity? Add(TEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();

        return entity;
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, bool enableAutoInclude=true)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if(filter is not null)
        {
            query = query.Where(filter);
           
        }

        if(enableAutoInclude is false)
        {
            query = query.IgnoreAutoIncludes();
           
        }


        return query.ToList();
    }

    public TEntity? GetById(TId id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    public TEntity? Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity? Update(TEntity entity)
    {
        entity.UpdatedDate = DateTime.Now;
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
        return entity;
    }

    
    //private DateTime NowTime(DateTime time)
    //{
    //    time = DateTime.Now;
    //    return time;
    //}
}
