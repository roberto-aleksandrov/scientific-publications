using ScientificPublications.Infrastructure.PasswordGenerators.Interfaces;

namespace ScientificPublications.WebUI.Models.Common
{
    public class PasswordGeneratorOptions : IPasswordGeneratorOptions
    {
        public string SecretKey { get; set; }

    }
}
