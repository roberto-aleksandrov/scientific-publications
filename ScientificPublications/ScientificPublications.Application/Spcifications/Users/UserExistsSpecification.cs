using ScientificPublications.Domain.Entities;

namespace ScientificPublications.Application.Spcifications.Users
{
    public class UserExistsSpecification : BaseSpecification<User>
    {
        public UserExistsSpecification(string username) 
            : base(n => n.Username == username) { }
    }
}
