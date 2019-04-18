namespace ScientificPublications.Infrastructure.Converters.MappingBuilders
{
    public class Mapping
    {
        public Mapping(string key, MapConfig mapConfig)
        {
            Key = key;
            MapConfig = mapConfig;
        }

        public string Key { get; }

        public MapConfig MapConfig { get; }
    }

}
