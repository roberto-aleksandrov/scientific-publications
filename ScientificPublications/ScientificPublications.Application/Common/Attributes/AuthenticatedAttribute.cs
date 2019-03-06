using System;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Application.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthenticatedAttribute : Attribute
    {
        public AuthenticatedAttribute() { }

        public AuthenticatedAttribute(string roles)
        {
            Roles = roles.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public IEnumerable<string> Roles { get; }
    }
}
