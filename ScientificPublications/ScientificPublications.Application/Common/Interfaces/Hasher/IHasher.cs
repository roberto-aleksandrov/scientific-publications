namespace ScientificPublications.Application.Common.Interfaces.Hasher
{
    public interface IHasher
    {
        string Create(string hashable, string salt);

        string Decrypt(string hashed, string salt);
    }
}
