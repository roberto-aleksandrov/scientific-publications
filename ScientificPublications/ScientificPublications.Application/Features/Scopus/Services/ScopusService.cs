using AutoMapper;
using ScientificPublications.Application.Common.Interfaces.Scopus;
using ScientificPublications.Application.Common.Models.Scopus;
using ScientificPublications.Application.Common.Services;
using ScientificPublications.Application.Features.Authors.Specifications;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities.AuthorsPublications;
using ScientificPublications.Domain.Entities.Publications;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Scopus.Services
{
    public class ScopusService : Service, IScopusService
    {
        private readonly IScopusApi _scopusApi;

        public ScopusService(IData data, IMapper mapper, IScopusApi scopusApi)
            : base(data, mapper)
        {
            _scopusApi = scopusApi;
        }

        public async Task SynchronizeWithScopusAsync()
        {
            var authors = await _data.Authors.ListAsync(new GetScopusAuthorsSpecification());

            foreach (var author in authors)
            {
                var response = await _scopusApi.GetAuthorPublications(new GetAuthorPublicationsRequest { AuthorScopusId = author.ScopusId });
                var publications = response.AuthorPublications.Where(p => author.AuthorsPublications.All(ap => ap.Publication.ScopusId != p.ScopusId));

                foreach (var publication in publications)
                {
                    author.AuthorsPublications.Add(new AuthorPublicationEntity
                    {
                        Publication = new PublicationEntity
                        {
                            ScopusId = publication.ScopusId,
                            Text = publication.Text,
                            Title = publication.Title
                        }
                    });
                }
            }
        }
    }
}
