using AutoMapper;
using MediatR;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Features.Roles.Commands;
using ScientificPublications.Application.Features.Roles.Specifications;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Authors.Commands.RegisterAuthor
{
    public class RegisterAuthorCommandHandler : BaseRequestHandler<RegisterAuthorCommand, AuthorEntity>
    {
        private readonly IMediator _mediator;

        public RegisterAuthorCommandHandler(IData data, IMapper mapper, IMediator mediator)
            : base(data, mapper)
        {
            _mediator = mediator;
        }

        private async Task AssignRoleToAuthor(AuthorEntity author)
        {
            var role = await _data.Roles.ListAsync(new GetRolesSpecification(Role.Author));

            author.User.UserRoles.Add(new UserRoleEntity { Role = role.Single() });
        }

        public override async Task<AuthorEntity> Handle(RegisterAuthorCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _mediator.Send(request.RegisterUser);
            var author = await _mediator.Send(request.CreateAuthor);

            author.User = userEntity;

            await AssignRoleToAuthor(author);

            await _data.Authors.AddAsync(author);

            return author;
        }

    }
}
