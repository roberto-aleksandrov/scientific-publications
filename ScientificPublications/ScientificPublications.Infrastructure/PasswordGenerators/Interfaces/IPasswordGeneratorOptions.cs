namespace ScientificPublications.Infrastructure.PasswordGenerators.Interfaces
{
    public interface IPasswordGeneratorOptions
    {
        string SecretKey { get; }
    }
}
