using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ScientificPublications.Infrastructure.Converters.MappingBuilders
{
    public class MappingsBuilder<TConvertible>
    {
        private readonly Mappings _mappings;
        private readonly List<string> _basePath;

        public MappingsBuilder()
            : this(new Mappings(), null)
        {
        }

        public MappingsBuilder(Mappings mappings, List<string> basePath)
        {
            _mappings = mappings;
            _basePath = basePath;
        }

        public Mappings Build()
        {
            return _mappings;
        }

        public MappingsBuilder<TConvertible> WithBasePath(string basePath)
        {
            return new MappingsBuilder<TConvertible>(_mappings, basePath.Split('.').ToList());
        }

        public MappingsBuilder<TConvertible> AddMap<TProperty>(Expression<Func<TConvertible, TProperty>> expression, Action<MapConfigBuilder> mapConfigBuildingExpression)
        {
            if (!(expression.Body is MemberExpression memberExpression))
            {
                return this;
            }

            var mapConfigBuilder = new MapConfigBuilder(_basePath);

            mapConfigBuildingExpression(mapConfigBuilder);

            _mappings.AddMapping(memberExpression.Member.Name, mapConfigBuilder.Build());

            return this;
        }

        public MappingsBuilder<TConvertible> AddMap<TProperty>(Expression<Func<TConvertible, TProperty>> expression, string jsonPropertyPath, Func<TProperty, TProperty> map = null)
        {
            if (!(expression.Body is MemberExpression memberExpression))
            {
                return this;
            }

            var path = _basePath != null
                ? _basePath.Concat(jsonPropertyPath.Split('.'))
                : jsonPropertyPath.Split('.');

            var mapConfig = new MapConfig { Path = path.ToList() };

            if (map != null)
            {
                mapConfig.AfterMap = new MapAction<TProperty>(map);
            }

            _mappings.AddMapping(memberExpression.Member.Name, mapConfig);

            return this;
        }

        public MappingsBuilder<TConvertible> AddMap<TProperty, TInnerConvertible>(Expression<Func<TConvertible, TProperty>> expression, string jsonPropertyPath, NameValueConverter<TInnerConvertible> converter)
        {
            if (!(expression.Body is MemberExpression memberExpression))
            {
                return this;
            }

            var path = _basePath != null
                ? _basePath.Concat(jsonPropertyPath.Split('.'))
                : jsonPropertyPath.Split('.');

            var mapConfig = new MapConfig { Path = path.ToList(), Converter = converter };

            _mappings.AddMapping(memberExpression.Member.Name, mapConfig);

            return this;
        }
    }
}
