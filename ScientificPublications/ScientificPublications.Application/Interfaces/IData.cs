using ScientificPublications.Domain.Entities;

namespace ScientificPublications.Application.Interfaces
{
    public interface IData
    {
        IAsyncRepository<User> Users { get; }
    }
}
