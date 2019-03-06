using Caelan.Frameworks.PasswordEncryption.Classes;
using ScientificPublications.Application.Common.Interfaces.Hasher;
using ScientificPublications.Infrastructure.PasswordGenerators.Interfaces;

namespace ScientificPublications.Infrastructure.PasswordGenerators
{
    public class PasswordGenerator : IHasher
    {
        private readonly string _secret;

        public PasswordGenerator(IPasswordGeneratorOptions secret)
        {
            _secret = secret.SecretKey;
        }

        public string Create(string hashable, string salt)
        {
            var passwordEncryptor = new PasswordEncryptor(hashable, _secret, salt);
            return passwordEncryptor.DefaultPasswordEncrypted;
        }

        public string Decrypt(string hashed, string salt)
        {
            var passwordEncryptor = new PasswordEncryptor("", _secret, salt);
            return passwordEncryptor.DecryptPassword(hashed);
        }
    }
}
