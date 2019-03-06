using AutoMapper;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities.Users;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.UserRoles.Commands
{
    public class CreateUserRoleCommandHandler : BaseRequestHandler<CreateUserRoleCommand, object>
    {
        public CreateUserRoleCommandHandler(IData data, IMapper mapper)
            : base(data, mapper) { }

        public override async Task<object> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var userRole = _mapper.Map<UserRoleEntity>(request);

            await _data.UserRoles.AddAsync(userRole);

            return userRole;
        }
    }
}
