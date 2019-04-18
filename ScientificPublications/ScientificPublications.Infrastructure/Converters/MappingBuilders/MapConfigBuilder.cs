using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Infrastructure.Converters.MappingBuilders
{
    public class MapConfigBuilder
    {
        private readonly MapConfig _mapConfig;
        private readonly List<string> _basePath;

        public MapConfigBuilder(List<string> basePath)
        {
            _mapConfig = new MapConfig();
            _basePath = basePath;
        }

        public MapConfigBuilder WithPath(string path)
        {
            _mapConfig.Path = _basePath != null 
                ? _basePath.Concat(path.Split('.')).ToList()
                : path.Split('.').ToList();

            return this;
        }

        public MapConfigBuilder BeforeMap(Func<JToken, JToken> func)
        {
            _mapConfig.BeforeMap = new MapAction<JToken>(func);

            return this;
        }

        public MapConfigBuilder WithConverter(JsonConverter converter)
        {
            _mapConfig.Converter = converter;

            return this;
        }

        public MapConfigBuilder AfterMap<TProperty>(Func<TProperty, TProperty> func)
        {
            _mapConfig.AfterMap = new MapAction<TProperty>(func);

            return this;
        }

        public MapConfig Build()
        {
            return _mapConfig;
        }
    }
}
