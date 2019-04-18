namespace ScientificPublications.Infrastructure.Converters.MappingBuilders.Interfaces
{
    public interface IMappings
    {
        void AddMapping(string propertyName, MapConfig mapConfig);

        MapConfig GetMapping(string propertyName);
    }
}
