using System;

namespace ScientificPublications.Application.Common.ViewModels
{
    public class BaseDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public Type InstanceType { get; set; }
    }
}
