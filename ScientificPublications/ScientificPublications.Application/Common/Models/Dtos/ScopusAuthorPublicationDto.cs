using Newtonsoft.Json;
using System.Collections.Generic;

namespace ScientificPublications.Application.Common.Models.Dtos
{
    public class ScopusAuthorPublicationDto
    {
        public string Title { get; set; }

        public string Text { get; set; }

        [JsonIgnore]
        public string ScopusId { get; set; }

        public List<ScopusAuthorDto> Authors { get; set; }
    }
}
