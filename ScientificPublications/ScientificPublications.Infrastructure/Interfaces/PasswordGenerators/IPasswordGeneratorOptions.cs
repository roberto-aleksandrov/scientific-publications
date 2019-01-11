namespace ScientificPublications.Infrastructure.Interfaces.PasswordGenerators
{
    public interface IPasswordGeneratorOptions
    {
        string SecretKey { get; }
    }
}
