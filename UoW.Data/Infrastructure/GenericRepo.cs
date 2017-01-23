using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UoW.Data.Infrastructure.Interfaces;

namespace UoW.Data.Infrastructure
{
    /// <summary>
    /// This base class will be inherited from all specific repositories and hence will implement the IGenericRepo interface.
    /// Since implementations marked as virtual, any repository can override a specific operation as required. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericRepo<T> where T : class
    {
        private UoWEntities dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected UoWEntities DbContext => dataContext ?? (dataContext = DbFactory.Init());

        protected GenericRepo(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public virtual void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        public virtual IEnumerable<T> GetBy(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }
    }
}
