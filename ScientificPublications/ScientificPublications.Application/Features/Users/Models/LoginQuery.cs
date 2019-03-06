using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Features.Users.Queries.Login;

namespace ScientificPublications.Application.Features.Users.Models
{
    public class LoginQuery : BaseQuery<LoginDto>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
