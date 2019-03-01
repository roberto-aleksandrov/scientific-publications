using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ScientificPublications.Infrastructure.Converters
{

    public abstract class BaseMap
    {
        public abstract object Exec(object mappable);

    }

    public class Map<TProperty> : BaseMap
    {
        private readonly Func<TProperty, object> _map;

        public Map(Func<TProperty, object> map)
        {
            _map = map;
        }
        
        public override object Exec(object mappable)
        {
            return _map((TProperty)mappable);
        }
    }

    public class MapConfig
    {
        public List<string> Path { get; set; }

        public JsonConverter Converter { get; set; }

        public BaseMap Map { get; set; }
    }

    public class NameValueConverter<TConvertible> : JsonConverter
    {
        protected readonly Dictionary<string, MapConfig> _propertyMappings;

        public NameValueConverter()
        {
            _propertyMappings = new Dictionary<string, MapConfig>();
        }

        protected void AddMap<TProperty>(Expression<Func<TConvertible, TProperty>> expression, string jsonPropertyName, Func<TProperty, object> map = null)
        {
            if (!(expression.Body is MemberExpression memberExpression))
            {
                return;
            }

            var mapConfig =  new MapConfig { Path = jsonPropertyName.Split('.').ToList()};

            if (map != null)
            {
                mapConfig.Map = new Map<TProperty>(map);
            }

            _propertyMappings.Add(memberExpression.Member.Name, mapConfig);
        }

        protected void AddMap<TProperty, TInnerConvertible>(Expression<Func<TConvertible, TProperty>> expression, string jsonPropertyName, NameValueConverter<TInnerConvertible> converter)
        {
            if (!(expression.Body is MemberExpression memberExpression))
            {
                return;
            }

            var mapConfig = new MapConfig { Path = jsonPropertyName.Split('.').ToList(), Converter = converter };

            _propertyMappings.Add(memberExpression.Member.Name, mapConfig);
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
                var mapConfig = _propertyMappings[property.Name];

                var targetValue = GetTargetValue(mapConfig.Path.ToList(), jobj);

                if (targetValue == null)
                {
                    continue;
                }

                var targetObject = mapConfig.Converter != null
                    ? mapConfig.Converter.ReadJson(targetValue.CreateReader(), property.PropertyType, null, null)
                    : targetValue.ToObject(property.PropertyType);

                targetObject = mapConfig.Map?.Exec(targetObject) ?? targetObject;

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
