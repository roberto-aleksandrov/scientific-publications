using System.Collections.Generic;

namespace ScientificPublications.Infrastructure.Converters.MappingBuilders
{
    public class Mappings
    {
        private readonly IDictionary<string, Mapping> _mappings;

        public Mappings()
        {
            _mappings = new Dictionary<string, Mapping>();
        }

        public void AddMapping(string propertyName, MapConfig mapConfig)
        {
            var mapping = new Mapping(propertyName, mapConfig);

            _mappings.Add(propertyName, mapping);
        }

        public MapConfig GetMapping(string propertyName)
        {
            return _mappings[propertyName].MapConfig;
        }
    }
}
