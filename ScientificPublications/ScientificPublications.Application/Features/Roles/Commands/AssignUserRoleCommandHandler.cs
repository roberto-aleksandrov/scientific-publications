using AutoMapper;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Common.Spcifications.Users;
using ScientificPublications.Application.Features.Roles.Specifications;
using ScientificPublications.Domain.Entities.Users;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Roles.Commands
{
    public class AssignUserRoleCommandHandler : BaseRequestHandler<AssignUserRoleCommand, UserRoleEntity>
    {
        public AssignUserRoleCommandHandler(IData data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public override async Task<UserRoleEntity> Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _data.Roles.ListAsync(new GetRolesSpecification(request.Role));
            var user = await _data.Users.ListAsync(new GetUserSpecification(request.UserId) { IncludeUncommited = true });

            var userRole = new UserRoleEntity
            {
                Role = role.Single(),
                User = user.Single()
            };

            await _data.UserRoles.AddAsync(userRole);

            return userRole;
        }
    }
}
