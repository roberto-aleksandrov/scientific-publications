using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ScientificPublications.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public Type InstanceType => GetType();
  
    }
}
