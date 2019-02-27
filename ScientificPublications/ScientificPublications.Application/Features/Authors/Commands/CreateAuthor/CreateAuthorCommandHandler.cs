using AutoMapper;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Common.Services;
using ScientificPublications.Application.Features.Authors.Models;
using ScientificPublications.Application.Features.Authors.Services;
using ScientificPublications.Application.Features.Users.Services.CreateUser;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities;
using ScientificPublications.Domain.Entities.Users;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : BaseRequestHandler<CreateAuthorCommand, AuthorDto>
    {
        private readonly IAuthorService _authorService;
        private readonly IUserService _userSerivce;

        public CreateAuthorCommandHandler(IData data, IMapper mapper, IAuthorService authorService, IUserService userSerivce)
            : base(data, mapper)
        {
            _authorService = authorService;
            _userSerivce = userSerivce;
        }

        public override async Task<AuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var user = await _userSerivce.CreateUserAsync(request.RegisterUser);

            var author = await _authorService.CreateAuthorByUserAsync(request, user);

            await _data.SaveChangesAsync();

            return _mapper.Map<AuthorDto>(author);

        }

    }
}
