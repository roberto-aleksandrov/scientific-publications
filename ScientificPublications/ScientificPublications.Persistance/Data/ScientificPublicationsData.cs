using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities;

namespace ScientificPublications.Infrastructure.Data
{
    public class ScientificPublicationsData : IData
    {

        public ScientificPublicationsData(IAsyncRepository<User> users)
        {
            Users = users;
        }

        public IAsyncRepository<User> Users { get; }
    }
}
