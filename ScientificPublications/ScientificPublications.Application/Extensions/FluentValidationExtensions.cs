using FluentValidation;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Constants.Validators;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Validators;
using ScientificPublications.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ScientificPublications.Application.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<TRequest, TProperty> None<TEntity, TRequest, TProperty>(
            this IRuleBuilder<TRequest, TProperty> ruleBuilder,
            IAsyncRepository<TEntity> repository,
            Func<TProperty, Expression<Func<TEntity, bool>>> criteria)
                where TEntity : Entity
        {
            return ruleBuilder.SetValidator(new NoneAsyncValidator<TProperty, TEntity>(criteria, repository));
        }

        public static IRuleBuilderOptions<TRequest, TProperty> Any<TEntity, TRequest, TProperty>(
         this IRuleBuilder<TRequest, TProperty> ruleBuilder,
         IAsyncRepository<TEntity> repository,
         Func<TProperty, Expression<Func<TEntity, bool>>> criteria)
             where TEntity : Entity
        {
            return ruleBuilder.SetValidator(new AnyAsyncValidator<TProperty, TEntity>(criteria, repository));
        }

        public static IRuleBuilderOptions<TRequest, IEnumerable<TProperty>> HasUnique<TRequest, TProperty>(
            this IRuleBuilder<TRequest, IEnumerable<TProperty>> ruleBuilder,
            Expression<Func<TProperty, object>> expression
            )
            where TRequest : IBaseRequest

        {
            return ruleBuilder.SetValidator(new UniqueValidator<TProperty, object>(expression));
        }
    }
}
