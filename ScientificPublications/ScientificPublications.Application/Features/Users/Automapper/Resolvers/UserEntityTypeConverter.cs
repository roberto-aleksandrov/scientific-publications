using AutoMapper;
using ScientificPublications.Application.Features.Users.Commands.RegisterUser;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Domain.Entities.Users;
using System;

namespace ScientificPublications.Application.Features.Users.Automapper.Resolvers
{
    public class UserEntityTypeConverter : ITypeConverter<RegisterUserCommand, UserEntity>
    {
        private readonly IHasher _hasher;

        public UserEntityTypeConverter(IHasher hasher)
        {
            _hasher = hasher;
        }

        public UserEntity Convert(RegisterUserCommand request, UserEntity entity, ResolutionContext context)
        {
            var salt = Guid.NewGuid().ToString();

            return new UserEntity
            {
                Username = request.Username,
                Password = _hasher.Create(request.Password, salt),
                Salt = salt
            };
        }
    }
}
