using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Features.Publications.Models;
using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Publications.Queries.GetPublications
{
    public class GetAllPublicationsQuery : BaseQuery<IEnumerable<PublicationDto>>
    {
    }
}
