using AutoMapper;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Features.Publications.Commands.CreatePublication;
using ScientificPublications.Application.Features.Publications.Models;
using ScientificPublications.Domain.Entities;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.Publications;

namespace ScientificPublications.Application.AutoMapper
{
    public class CommandToEntityProfile : Profile
    {
        public CommandToEntityProfile()
            : base()
        {
            CreateMap<CreatePublicationCommand, PublicationEntity>();

            CreateMap<AuthorPublicationDto, AuthorPublicationEntity>();

        }
    }
}
