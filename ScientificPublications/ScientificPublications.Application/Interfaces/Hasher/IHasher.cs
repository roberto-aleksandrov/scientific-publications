namespace ScientificPublications.Application.Interfaces.Hasher
{
    public interface IHasher
    {
        string Create(string hashable);

        string Create(string hashable, string secret);

        string Create(string hashable, string secret, string salt);
    }
}
