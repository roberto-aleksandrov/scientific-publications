using AutoMapper;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.Publications;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Features.Publications.Automapper.Resolvers
{
    public class AuthorsValueResolver : IValueResolver<CreatePublicationCommand, PublicationEntity, ICollection<AuthorPublicationEntity>>
    {
        private readonly IData _data;

        public AuthorsValueResolver(IData data)
        {
            _data = data;
        }

        public ICollection<AuthorPublicationEntity> Resolve(CreatePublicationCommand request, PublicationEntity destination, ICollection<AuthorPublicationEntity> destMember, ResolutionContext context)
        {
            return request.AuthorIds.Select(id => new AuthorPublicationEntity { AuthorId = id }).ToList();
        }
    }
}
