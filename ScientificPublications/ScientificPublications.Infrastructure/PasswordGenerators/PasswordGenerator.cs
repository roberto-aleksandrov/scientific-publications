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
            var passwordEncryptor = new PasswordEncryptor(hashable, _secret, Guid.NewGuid().ToString());
            return passwordEncryptor.DefaultPasswordEncrypted;
        }

        public string Decrypt(string hashed, string salt)
        {
            var passwordEncryptor = new PasswordEncryptor("", _secret, salt);
            return passwordEncryptor.DecryptPassword(hashed);
        }
    }
}
