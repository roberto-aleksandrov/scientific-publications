using ScientificPublications.Application.Interfaces;
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
