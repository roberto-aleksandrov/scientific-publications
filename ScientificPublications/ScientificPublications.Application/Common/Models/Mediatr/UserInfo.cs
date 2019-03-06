using System.Collections.Generic;

namespace ScientificPublications.Application.Common.Models.Mediatr
{
    public class UserInfo
    {
        public bool Authenticated { get; set; }

        public string Username { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
