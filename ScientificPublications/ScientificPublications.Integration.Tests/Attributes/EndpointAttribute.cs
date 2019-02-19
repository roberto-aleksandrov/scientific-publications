using System;

namespace ScientificPublications.Integration.Tests.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EndpointAttribute : Attribute
    {
        public EndpointAttribute(string name)
            : this(null, name)
        {
        }

        public EndpointAttribute(string controller, string name)
        {
            Name = name;
            Controller = controller;
        }

        public string Controller { get; set; }

        public string Name { get; }
    }
}
