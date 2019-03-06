using FluentValidation.Validators;
using ScientificPublications.Application.Common.Constants.Validators;
using ScientificPublications.Application.Common.Models.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Common.Validators
{
    public class QueryValidator<TQuery, TEntity> : AsyncValidator
        where TQuery : IBaseQuery
    {
        public QueryValidator()
            : base(ErrorMessages.InvalidInclude)
        {
        }

        private bool VerifyInclude(Queue<string> include, Type entityType)
        {
            if (!include.Any())
            {
                return true;
            }

            var inc = include.Dequeue();

            var prop = entityType.GetProperties()
                    .Where(p => p.Name == inc)
                    .FirstOrDefault();


            return prop != null ? VerifyInclude(include, prop.PropertyType) : false;
        }

        private bool VerifyIncludes(Queue<string> includes)
        {
            if (!includes.Any())
            {
                return true;
            }

            var include = includes.Dequeue();

            return VerifyInclude(new Queue<string>(include.Split('.')), typeof(TEntity))
                ? VerifyIncludes(includes)
                : false;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var query = (TQuery)context.PropertyValue;

            try
            {
                var includes = query.Include?.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)?.ToList();
                var queue = new Queue<string>(includes ?? new List<string>());

                return VerifyIncludes(queue);
            }
            catch
            {
                return false;
            }
        }
    }
}
