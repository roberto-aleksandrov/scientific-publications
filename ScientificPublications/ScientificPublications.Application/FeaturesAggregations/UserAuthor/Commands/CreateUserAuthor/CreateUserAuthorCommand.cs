using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Features.Authors.Models;
using System.Collections.Generic;

namespace ScientificPublications.Application.FeaturesAggregations.UserAuthor.Commands.CreateUserAuthor
{
    public class CreateUserAuthorCommand : BaseRequest<AuthorDto>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsCathedralMember { get; set; }

        public string ScopusId { get; set; }

        public ICollection<string> Aliases { get; set; }

    }
}
