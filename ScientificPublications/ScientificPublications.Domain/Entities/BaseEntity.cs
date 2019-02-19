using System;

namespace ScientificPublications.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public Type InstanceType => GetType();
    }
}
