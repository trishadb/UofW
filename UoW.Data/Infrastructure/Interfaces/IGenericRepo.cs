using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace UoW.Data.Infrastructure.Interfaces
{
    /// <summary>
    /// IGenericRepo interfaces where all default operations are declared
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericGets<TEntity> where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> whereClause);
        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> whereClause);
    }

    /// <summary>
    /// Marks an entity as new
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericCreate<in TEntity> where TEntity : class
    {
        void Create(TEntity tbl);
    }
    /// <summary>
    /// Marks an entity as modified
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericUpdate<in TEntity> where TEntity : class
    {
        void Update(TEntity tbl);
    }
    /// <summary>
    /// Marks an entity to be removed
    /// </summary>
    public interface IGenericDelete
    {
        void Delete(int id);
    }
}
