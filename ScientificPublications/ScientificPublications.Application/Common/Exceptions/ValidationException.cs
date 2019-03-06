using FluentValidation.Results;
using ScientificPublications.Application.Common.Constants.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(ErrorTypes errorType, List<ValidationFailure> failures)
            : this(failures)
        {
            ErrorType = errorType;
        }

        public ValidationException(ErrorTypes errorType)
        {
            ErrorType = errorType;
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
            .Select(e => e.PropertyName)
            .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }

        public ErrorTypes ErrorType { get; }
    }
}
