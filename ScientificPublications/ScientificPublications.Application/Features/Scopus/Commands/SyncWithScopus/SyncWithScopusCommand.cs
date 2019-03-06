using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities.Publications;
using System.Collections.Generic;

namespace ScientificPublications.Application.Features.Scopus.Commands.SyncWithScopus
{
    public class SyncWithScopusCommand : BaseCommand<IEnumerable<PublicationEntity>>
    {
    }
}
