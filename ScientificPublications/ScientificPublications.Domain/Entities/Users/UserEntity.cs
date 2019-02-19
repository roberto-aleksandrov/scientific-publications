namespace ScientificPublications.Domain.Entities.Users
{
    public class UserEntity : BaseEntity
    {
        public AuthorEntity Author { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

    }
}
