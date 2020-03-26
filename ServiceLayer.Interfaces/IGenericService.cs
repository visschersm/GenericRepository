using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ServiceLayer.Interfaces
{
    public interface IGenericService<TEntity>
        where TEntity : class
    {
        Task<TView> GetById<TView>(object id, Expression<Func<TEntity, TView>>? selectExpression = null)
            where TView : IViewOf<TEntity>;
        Task<IEnumerable<TView>> Get<TView>(Expression<Func<TEntity, bool>>? where = null, Expression<Func<TEntity, TView>>? selectExpression = null)
            where TView : IViewOf<TEntity>;

        Task<TView> Create<TView>(ICreate<TEntity> toCreate, Expression<Func<TEntity, TView>>? selectExpression = null)
            where TView : IViewOf<TEntity>;
    }
}
