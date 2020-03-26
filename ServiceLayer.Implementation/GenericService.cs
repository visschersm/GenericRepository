using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Entities.Interfaces;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ServiceLayer.Implementation
{
    public class GenericService<TEntity> : IGenericService<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ITodoContext _context;
        private readonly DbSet<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(ITodoContext context, IMapper mapper)
        {
            _context = context;
            _repository = _context.Set<TEntity>();

            _mapper = mapper;
        }

        public async Task<IEnumerable<TView>> Get<TView>(Expression<Func<TEntity, bool>>? where, Expression<Func<TEntity, TView>>? selectExpression)
            where TView : IViewOf<TEntity>
        {
            var query = _repository.AsNoTracking();

            if (where != null)
                query = query.Where(where);

            if (selectExpression == null)
                return await query.ProjectTo<TView>(_mapper.ConfigurationProvider).ToArrayAsync();

            return await query.Select(selectExpression)
                .ToArrayAsync();
        }

        public async Task<TView> GetById<TView>(object id, Expression<Func<TEntity, TView>>? selectExpression)
            where TView : IViewOf<TEntity>
        {
            var query = _repository.AsNoTracking()
                .Where(x => x.Id == id);

            if (selectExpression == null)
                return await query.ProjectTo<TView>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

            return await query.Select(selectExpression)
                .SingleOrDefaultAsync();
        }

        public async Task<TView> Create<TView>(ICreate<TEntity> toCreate, Expression<Func<TEntity, TView>>? selectExpression)
            where TView : IViewOf<TEntity>
        {
            var data = _mapper.Map<TEntity>(toCreate);

            var created = _repository.Add(data).Entity;
            await _context.SaveChangesAsync();

            return _mapper.Map<TView>(created);
        }
    }
}
