using MediatR;

namespace ScientificPublications.Application.Common.Requests
{
    public class BaseRequest<T> : IBaseRequest, IRequest<T>
    {
        public UserInfo UserInfo { get; set; }
    }
}
