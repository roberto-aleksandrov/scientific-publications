using FluentValidation.Validators;
using ScientificPublications.Application.Common.Constants.Validators;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Spcifications;
using ScientificPublications.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace ScientificPublications.Application.Common.Validators
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
            var criteria = _criteria((TProperty)context.PropertyValue);
            var specification = new BaseSpecification<TEntity>(criteria);
            var entities = await _repository.ListAsync(specification);

            return entities.Any();
        }
    }
}
