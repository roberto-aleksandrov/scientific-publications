using FluentValidation.Validators;
using ScientificPublications.Application.Constants.Validators;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Spcifications;
using ScientificPublications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace ScientificPublications.Application.Infrastructure.Validators
{
    public class AnyAsyncValidator<TProperty, TEntity> : AsyncValidator
          where TEntity : BaseEntity
    {
        private readonly Func<TProperty, Expression<Func<TEntity, bool>>> _criteria;
        private readonly IAsyncRepository<TEntity> _repository;

        public AnyAsyncValidator(
            Func<TProperty, Expression<Func<TEntity, bool>>> criteria,
            IAsyncRepository<TEntity> repository)
            : base(ErrorMessages.EntityDoesNotExists)
        {
            _repository = repository;
            _criteria = criteria;
        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            Expression<Func<TEntity, bool>> criteria = _criteria((TProperty)context.PropertyValue);
            BaseSpecification<TEntity> specification = new BaseSpecification<TEntity>(criteria);
            IReadOnlyList<TEntity> entities = await _repository.ListAsync(specification);

            return entities.Any();
        }
    }
}
