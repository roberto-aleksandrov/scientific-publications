using ScientificPublications.Infrastructure.Interfaces.PasswordGenerators;

namespace ScientificPublications.WebUI.Models.Common
{
    public class PasswordGeneratorOptions : IPasswordGeneratorOptions
    {
        public string SecretKey { get; set; }

    }
}
