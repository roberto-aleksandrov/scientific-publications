using ScientificPublications.Application.Common.ViewModels;

namespace ScientificPublications.Application.Features.AuthorsAliases.Models
{
    public class AuthorAliasDto : BaseDto
    {
        public string Alias { get; set; }

        public int AuthorId { get; set; }
        
    }
}
