using AutoMapper;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Features.Authors.Models;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Domain.Entities.Users;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : BaseRequestHandler<CreateAuthorCommand, AuthorDto>
    {
        private readonly IHasher _hasher;

        public CreateAuthorCommandHandler(IData data, IMapper mapper, IHasher hasher)
            : base(data, mapper)
        {
            _hasher = hasher;
        }

        public override async Task<AuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _data.Authors.AddAsync(_mapper.Map<AuthorEntity>(request));

            return _mapper.Map<AuthorDto>(author);

        }

    }
}
