using ScientificPublications.Application.Common.Models.Mediatr;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScientificPublications.Infrastructure.Mediator.Interfaces
{
    public interface IPersistableMediator
    {
        Task<TResponse> Send<TResponse>(BaseQuery<TResponse> request);

        Task<List<int>> Send<TResponse>(BaseCommand<TResponse> request);
    }
}
