using AutoMapper;
using MediatR;
using ScientificPublications.Application.Common.Interfaces.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Common.Models.Mediatr
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        protected readonly IData _data;
        protected readonly IMapper _mapper;

        public BaseRequestHandler(IData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
