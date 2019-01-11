using ScientificPublications.Domain.Entities;

namespace ScientificPublications.Application.Interfaces.Data
{
    public interface IData
    {
        IAsyncRepository<User> Users { get; }
    }
}
