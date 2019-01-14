using FluentValidation;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Infrastructure.Validators;
using ScientificPublications.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ScientificPublications.Application.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<TRequest, TProperty> None<TEntity, TRequest, TProperty>(
            this IRuleBuilder<TRequest, TProperty> ruleBuilder,
            IAsyncRepository<TEntity> repository,
            Func<TProperty, Expression<Func<TEntity, bool>>> criteria)
                where TEntity : BaseEntity
        {
            return ruleBuilder.SetValidator(new NoneAsyncValidator<TProperty, TEntity>(criteria, repository));
        }

        public static IRuleBuilderOptions<TRequest, TProperty> Any<TEntity, TRequest, TProperty>(
         this IRuleBuilder<TRequest, TProperty> ruleBuilder,
         IAsyncRepository<TEntity> repository,
         Func<TProperty, Expression<Func<TEntity, bool>>> criteria)
             where TEntity : BaseEntity
        {
            return ruleBuilder.SetValidator(new AnyAsyncValidator<TProperty, TEntity>(criteria, repository));
        }
    }
}
