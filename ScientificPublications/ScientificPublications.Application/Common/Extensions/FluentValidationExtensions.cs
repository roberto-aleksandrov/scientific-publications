using FluentValidation;
using ScientificPublications.Application.Common.Constants.Validators;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Common.Validators;
using ScientificPublications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ScientificPublications.Application.Common.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<TRequest, TProperty> HasNoneDb<TEntity, TRequest, TProperty>(
            this IRuleBuilder<TRequest, TProperty> ruleBuilder,
            IAsyncRepository<TEntity> repository,
            Func<TProperty, Expression<Func<TEntity, bool>>> criteria)
                where TEntity : BaseEntity
        {
            return ruleBuilder.SetValidator(new NoneAsyncValidator<TProperty, TEntity>(criteria, repository));
        }

        public static IRuleBuilderOptions<TRequest, TProperty> HasAnyDb<TEntity, TRequest, TProperty>(
            this IRuleBuilder<TRequest, TProperty> ruleBuilder,
            IAsyncRepository<TEntity> repository,
            Func<TProperty, Expression<Func<TEntity, bool>>> criteria)
                 where TEntity : BaseEntity
        {
            return ruleBuilder.SetValidator(new AnyAsyncValidator<TProperty, TEntity>(criteria, repository));
        }

        public static IRuleBuilderOptions<TRequest, TProperty> IsTrueDb<TEntity, TRequest, TProperty>(
            this IRuleBuilder<TRequest, TProperty> ruleBuilder,
            IAsyncRepository<TEntity> repository,
            Func<TProperty, IReadOnlyCollection<TEntity>, bool> criteria,
            Func<TProperty, ISpecification<TEntity>> spec = null,
            string errorMessage = ErrorMessages.Invalid)
                where TEntity : BaseEntity
        {
            return ruleBuilder.SetValidator(new IsTrueAsyncValidator<TProperty, TEntity>(criteria, repository, spec, errorMessage));
        }

        public static IRuleBuilderOptions<TRequest, IEnumerable<TProperty>> HasUnique<TRequest, TProperty>(
            this IRuleBuilder<TRequest, IEnumerable<TProperty>> ruleBuilder,
            Expression<Func<TProperty, object>> expression)
                where TRequest : IBaseRequest

        {
            return ruleBuilder.SetValidator(new UniqueValidator<TProperty, object>(expression));
        }
        public static IRuleBuilderOptions<TRequest, TRequest> IsValidQuery<TRequest, TEntity>(
            this IRuleBuilder<TRequest, TRequest> ruleBuilder)
                where TRequest : IBaseQuery

        {
            return ruleBuilder.SetValidator(new QueryValidator<TRequest, TEntity>());
        }
    }
}
