using FluentValidation.Validators;
using ScientificPublications.Application.Constants.Validators;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Validators
{
    public class TestDbValidator<TProperty, TEntity> : AsyncValidator
          where TEntity : BaseEntity
    {
        private readonly Func<TProperty, IReadOnlyCollection<TEntity>, bool> _criteria;
        private readonly Func<TProperty, ISpecification<TEntity>> _spec;
        private readonly IAsyncRepository<TEntity> _repository;

        public TestDbValidator(
             Func<TProperty, IReadOnlyCollection<TEntity>, bool> criteria,
            IAsyncRepository<TEntity> repository,
            Func<TProperty, ISpecification<TEntity>> spec)
            : base(ErrorMessages.EntityExists)
        {
            _repository = repository;
            _spec = spec;
            _criteria = criteria;
        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var prop = (TProperty)context.PropertyValue;
            var entities = _spec == null
                ? await _repository.ListAllAsync()
                : await _repository.ListAsync(_spec(prop));

            return _criteria(prop, entities);
        }
    }
}
