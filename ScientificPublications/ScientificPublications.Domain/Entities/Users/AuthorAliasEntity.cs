namespace ScientificPublications.Domain.Entities.Users
{
    public class AuthorAliasEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Alias { get; set; }

        public int AuthorId { get; set; }

        public AuthorEntity Author { get; set; }
    }
}
