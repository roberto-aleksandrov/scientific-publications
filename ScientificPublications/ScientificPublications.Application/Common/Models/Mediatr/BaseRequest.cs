using MediatR;

namespace ScientificPublications.Application.Common.Models.Mediatr
{
    public class BaseRequest<T> : IBaseRequest, IRequest<T>
    {
        public UserInfo UserInfo { get; set; }
    }
}
