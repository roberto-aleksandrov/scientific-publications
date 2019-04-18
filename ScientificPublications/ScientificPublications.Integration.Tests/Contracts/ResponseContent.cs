using System;

namespace ScientificPublications.Integration.Tests.Contracts
{
    public class ResponseContent
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public Type InstanceType { get; set; }
    }
}
