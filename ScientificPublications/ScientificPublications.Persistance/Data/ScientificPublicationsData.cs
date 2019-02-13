using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Infrastructure.Data
{
    public class ScientificPublicationsData : IData
    {
        public ScientificPublicationsData(
            IAsyncRepository<UserEntity> users,
            IAsyncRepository<PublicationEntity> publications)
        {
            Users = users;
            Publications = publications;
        }

        public IAsyncRepository<UserEntity> Users { get; }

        public IAsyncRepository<PublicationEntity> Publications { get; }
    }
}
