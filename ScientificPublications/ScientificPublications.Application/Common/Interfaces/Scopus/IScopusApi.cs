using ScientificPublications.Application.Common.Models.Scopus;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Common.Interfaces.Scopus
{
    public interface IScopusApi
    {
        Task<GetAuthorPublicationsResponse> GetAuthorPublications(GetAuthorPublicationsRequest getAuthorPublicationsRequest);

        Task<GetAuthorDocumentsResponse> GetAuthorDocuments(GetAuthorDocumentsRequest getAuthorDocumentsRequest);
    }
}
