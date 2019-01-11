using FluentValidation;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Validators;
using ScientificPublications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ScientificPublications.Application.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<TRequest, TProperty> ValidateEntities<TEntity, TRequest, TProperty>(
            this IRuleBuilder<TRequest, TProperty> ruleBuilder,
            Func<TProperty, Expression<Func<TEntity, bool>>> criteria,
            IAsyncRepository<TEntity> repository)
                where TEntity : BaseEntity
        {
            return ruleBuilder.SetValidator(new EntitiestAsyncValidator<TProperty, TEntity>(criteria, repository));
        }
    }
}
