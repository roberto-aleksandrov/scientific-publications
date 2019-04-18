using Microsoft.EntityFrameworkCore;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificPublications.Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly ScientificPublicationsContext _dbContext;

        public EfRepository(ScientificPublicationsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> SingleAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).SingleAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            return Task.FromResult(entity);
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            return Task.CompletedTask;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var set = _dbContext.Set<T>().AsQueryable();
            var localSet = _dbContext.Set<T>().Local.AsQueryable();
            var queriable = spec.IncludeUncommited
                ? set.Concat(localSet.Where(n => _dbContext.Entry(n).State == EntityState.Added))
                : set;

            return SpecificationEvaluator<T>.GetQuery(queriable, spec);
        }
    }
}
