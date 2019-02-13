using Microsoft.EntityFrameworkCore;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities;
using System.Linq;

namespace ScientificPublications.Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : Entity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;
            
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            
            query = specification.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));
            
            query = specification.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));
            
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.isPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                             .Take(specification.Take);
            }
            return query;
        }
    }
}
