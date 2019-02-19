using ScientificPublications.Application.Common.ViewModels;

namespace ScientificPublications.Application.Features.Users.Models
{
    public class UserDto : BaseDto
    {
        public int? AuthorId { get; set; }

        public string Username { get; set; }

    }
}
