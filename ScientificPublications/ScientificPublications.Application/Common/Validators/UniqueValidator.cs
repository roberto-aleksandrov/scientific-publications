using FluentValidation.Validators;
using ScientificPublications.Application.Common.Constants.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ScientificPublications.Application.Common.Validators
{
    public class UniqueValidator<T, TKey> : AsyncValidator
    {
        private readonly Expression<Func<T, TKey>> _expression;

        public UniqueValidator(Expression<Func<T, TKey>> predicate)
            : base(ErrorMessages.NotUnique)
        {
            _expression = predicate;
        }

        protected override void PrepareMessageFormatterForValidationError(PropertyValidatorContext context)
        {
            try
            {
                var unExp = (UnaryExpression)_expression.Body;
                var name = ((MemberExpression)unExp.Operand).Member.Name;
                context.MessageFormatter.AppendArgument("PropertyName", name);
            }
            catch
            {
                context.MessageFormatter.AppendArgument("PropertyName", "");
            }
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return !((IEnumerable<T>)context.PropertyValue)
                .GroupBy(_expression.Compile())
                .Where(n => n.Count() > 1)
                .Any();
        }
    }
}
