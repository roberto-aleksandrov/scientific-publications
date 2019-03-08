using AutoMapper;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities.Users;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : BaseRequestHandler<CreateAuthorCommand, AuthorEntity>
    {
        public CreateAuthorCommandHandler(IData data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public override async Task<AuthorEntity> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<AuthorEntity>(request);

            await _data.Authors.AddAsync(author);

            return author;
        }
    }
}
