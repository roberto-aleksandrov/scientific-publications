namespace ScientificPublications.Infrastructure.Scopus.Options
{
    public interface IScopusApiOptions
    {
        string ApiKey { get; }

        string Url { get; }
    }
}
