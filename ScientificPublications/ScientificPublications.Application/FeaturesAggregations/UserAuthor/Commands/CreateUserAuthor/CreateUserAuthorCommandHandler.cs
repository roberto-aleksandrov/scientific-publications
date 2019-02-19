using AutoMapper;
using MediatR;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Features.Authors.Commands.CreateAuthor;
using ScientificPublications.Application.Features.Authors.Models;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Application.Interfaces.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.FeaturesAggregations.UserAuthor.Commands.CreateUserAuthor
{
    public class CreateUserAuthorCommandHandler : BaseRequestHandler<CreateUserAuthorCommand, AuthorDto>
    {
        private readonly IMediator _mediator;

        public CreateUserAuthorCommandHandler(IData data, IMapper mapper, IMediator mediator)
            : base(data, mapper)
        {
            _mediator = mediator;
        }

        public override async Task<AuthorDto> Handle(CreateUserAuthorCommand request, CancellationToken cancellationToken)
        {
            var createUserCommand = _mapper.Map<RegisterUserCommand>(request);

            var user = await _mediator.Send(createUserCommand);

            var createAuthorCommand = _mapper.Map<CreateAuthorCommand>(request);
            createAuthorCommand.UserId = user.Id;

            var author = await _mediator.Send(createAuthorCommand);

            return author;
        }
    }
}
