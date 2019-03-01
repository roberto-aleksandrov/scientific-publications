using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Scopus.Services
{
    public interface IScopusService
    {
        Task SynchronizeWithScopusAsync();
    }
}
