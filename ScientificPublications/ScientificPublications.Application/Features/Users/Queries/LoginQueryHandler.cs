using MediatR;
using ScientificPublications.Application.Interfaces.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Users.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginViewModel>
    {
        private readonly IData _data;

        public LoginQueryHandler(IData data)
        {
            _data = data;
        }

        public Task<LoginViewModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
