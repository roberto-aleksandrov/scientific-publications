using FluentValidation;
using MediatR;
using ScientificPublications.Application.Common.Attributes;
using ScientificPublications.Application.Common.Constants.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Common.Middlewares
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
      where TRequest : Models.Mediatr.IBaseRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public AuthorizationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var authorizationAttribute = _validators
                .Select(n => n.GetType()
                        .GetCustomAttributes(typeof(AuthenticatedAttribute), true)
                        .FirstOrDefault()).FirstOrDefault();

            if (authorizationAttribute != null && !request.UserInfo.Authenticated)
            {
                throw new Exceptions.ValidationException(ErrorTypes.Authentication);
            }

            return await next();
        }
    }

}
