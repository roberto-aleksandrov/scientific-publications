namespace ScientificPublications.Application.Features.AuthorsAliases.Commands.CreateAuthorAlias
{
    public class CreateAuthorAliasCommand
    {
        public int AuthorId { get; set; }

        public string Alias { get; set; }
    }
}
