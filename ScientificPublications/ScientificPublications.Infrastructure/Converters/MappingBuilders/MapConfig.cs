using Newtonsoft.Json;
using ScientificPublications.Infrastructure.Converters.MappingBuilders.Interfaces;
using System.Collections.Generic;

namespace ScientificPublications.Infrastructure.Converters.MappingBuilders
{
    public class MapConfig
    {
        public List<string> Path { get; set; }

        public JsonConverter Converter { get; set; }

        public IMapAction BeforeMap { get; set; }

        public IMapAction AfterMap { get; set; }

    }
}
