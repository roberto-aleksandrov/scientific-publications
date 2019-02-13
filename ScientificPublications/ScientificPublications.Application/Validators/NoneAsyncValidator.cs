using FluentValidation.Validators;
using ScientificPublications.Application.Constants.Validators;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Spcifications;
using ScientificPublications.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Validators
{
    public class NoneAsyncValidator<TProperty, TEntity> : AsyncValidator
          where TEntity : Entity
    {
        private readonly Func<TProperty, Expression<Func<TEntity, bool>>> _criteria;
        private readonly IAsyncRepository<TEntity> _repository;

        public NoneAsyncValidator(
            Func<TProperty, Expression<Func<TEntity, bool>>> criteria,
            IAsyncRepository<TEntity> repository)
            : base(ErrorMessages.EntityExists)
        {
            _repository = repository;
            _criteria = criteria;
        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var criteria = _criteria((TProperty)context.PropertyValue);
            var specification = new BaseSpecification<TEntity>(criteria);
            var entities = await _repository.ListAsync(specification);

            return !entities.Any();
        }
    }
}
