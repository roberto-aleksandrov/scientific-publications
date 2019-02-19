using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Features.Users.Queries;

namespace ScientificPublications.Application.Features.Users.Models
{
    public class LoginQuery : BaseRequest<LoginDto>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
