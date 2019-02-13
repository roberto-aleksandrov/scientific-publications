using ScientificPublications.Application.Common.Requests;

namespace ScientificPublications.Application.Features.Users.Queries
{
    public class LoginQuery : BaseRequest<LoginViewModel>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
