using AutoMapper;
using MediatR;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Features.Roles.Specifications;
using ScientificPublications.Domain.Entities.Users;
using ScientificPublications.Domain.Enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : BaseRequestHandler<CreateAuthorCommand, AuthorEntity>
    {
        private readonly IMediator _mediator;

        public CreateAuthorCommandHandler(IData data, IMapper mapper, IMediator mediator)
            : base(data, mapper)
        {
            _mediator = mediator;
        }

        public override async Task<AuthorEntity> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _mediator.Send(request.RegisterUser);

            var author = _mapper.Map<AuthorEntity>(request);

            var role = (await _data.Roles.ListAsync(new GetRolesSpecification(Role.Author))).First();

            userEntity.UserRoles.Add(new UserRoleEntity { Role = role });

            author.User = userEntity;

            await _data.Authors.AddAsync(author);

            return author;
        }

    }
}
