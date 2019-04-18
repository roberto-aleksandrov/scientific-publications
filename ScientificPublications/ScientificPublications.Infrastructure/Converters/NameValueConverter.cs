using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScientificPublications.Infrastructure.Converters.MappingBuilders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ScientificPublications.Infrastructure.Converters
{

    public class NameValueConverter<TConvertible> : JsonConverter
    {
        private readonly MappingsBuilder<TConvertible> _mappingsBuilder;
        private Mappings _mappings;

        public NameValueConverter()
        {
            _mappingsBuilder = new MappingsBuilder<TConvertible>();
        }

        protected void CreateaMappings(Action<MappingsBuilder<TConvertible>> func)
        {
            func(_mappingsBuilder);
            _mappings = _mappingsBuilder.Build();
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jtoken = JToken.ReadFrom(reader);
            var obj = Activator.CreateInstance(objectType);

            if (typeof(IEnumerable).IsAssignableFrom(objectType))
            {
                var jArray = jtoken;

                if (jtoken.GetType() != typeof(JArray))
                {
                    jArray = new JArray(jtoken);
                }

                foreach (var jobj in jArray)
                {
                    var element = HandleObject(objectType.GetGenericArguments()[0], jobj, Activator.CreateInstance(objectType.GetGenericArguments()[0]));

                    objectType.GetMethod("Add").Invoke(obj, new[] { element });
                }

                return obj;
            }

            return HandleObject(objectType, jtoken, obj);
        }

        private object HandleObject(Type objectType, JToken jobj, object obj)
        {
            var properties = objectType.GetProperties()
                .Where(n => n.GetCustomAttributes(true).OfType<JsonIgnoreAttribute>().FirstOrDefault() == null);

            foreach (var property in properties)
            {
                var mapConfig = _mappings.GetMapping(property.Name);

                var targetValue = GetTargetValue(mapConfig.Path.ToList(), jobj);

                if (targetValue == null)
                {
                    continue;
                }
                
                var targetObject = mapConfig.Converter != null
                    ? mapConfig.Converter.ReadJson(targetValue.CreateReader(), property.PropertyType, null, null)
                    : (mapConfig.BeforeMap?.Exec(targetValue) as JToken)?.ToObject(property.PropertyType) ?? targetValue.ToObject(property.PropertyType);

                targetObject = mapConfig.AfterMap?.Exec(targetObject) ?? targetObject;

                property.SetValue(obj, targetObject);
            }

            return obj;
        }

        private JToken GetTargetValue(ICollection<string> path, JToken jobj)
        {
            JToken targetValue;
            var next = path.FirstOrDefault();

            if (next == null)
            {
                return jobj;
            }

            targetValue = jobj[next];

            if (targetValue == null)
            {
                return null;
            }

            if (path.Count > 1 && jobj[next] is JArray jArray)
            {
                path.Remove(next);

                next = path.First();

                targetValue = new JArray(jArray.SelectMany(n => n[next]));
            }

            path.Remove(next);

            return GetTargetValue(path, targetValue);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
