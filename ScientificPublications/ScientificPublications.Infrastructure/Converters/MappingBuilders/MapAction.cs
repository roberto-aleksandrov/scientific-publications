using ScientificPublications.Infrastructure.Converters.MappingBuilders.Interfaces;
using System;

namespace ScientificPublications.Infrastructure.Converters.MappingBuilders
{
    public class MapAction<TProperty> : IMapAction
    {
        private readonly Func<TProperty, TProperty> _func;

        public MapAction(Func<TProperty, TProperty> func)
        {
            _func = func;
        }

        public object Exec(object mappable)
        {
            return _func((TProperty)mappable);
        }
    }
}
