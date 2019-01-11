using Caelan.Frameworks.PasswordEncryption.Classes;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Infrastructure.Interfaces.PasswordGenerators;
using System;

namespace ScientificPublications.Infrastructure.PasswordGenerators
{
    public class PasswordGenerator : IHasher
    {
        private readonly string _secret;

        public PasswordGenerator(IPasswordGeneratorOptions secret)
        {
            _secret = secret.SecretKey;
        }

        public string Create(string hashable)
        {
            return Create(hashable, _secret);
        }

        public string Create(string hashable, string secret)
        {
            return Create(hashable, secret, Guid.NewGuid().ToString());
        }

        public string Create(string hashable, string secret, string salt)
        {
            var passwordEncryptor = new PasswordEncryptor(hashable, secret, salt);
            return passwordEncryptor.DefaultPasswordEncrypted;
        }
    }
}
