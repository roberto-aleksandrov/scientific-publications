using ScientificPublications.Application.Common.Interfaces.Hasher;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Integration.Tests.Seed.Hooks
{
    public class UserHook : IPreSeedHook<UserEntity>
    {
        private readonly IHasher _hasher;

        public UserHook(IHasher hasher)
        {
            _hasher = hasher;
        }

        public UserEntity Execute(object entity)
        {
            var userEntity = (UserEntity)entity;
            
            userEntity.Password = _hasher.Create(userEntity.Password, userEntity.Salt);

            return userEntity;
        }
    }
}
