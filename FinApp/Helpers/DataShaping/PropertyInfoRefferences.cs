using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace FinApp.Api.Helpers.DataShaping
{
    public class PropertyInfoRefferences<T>
    {
        private const BindingFlags BindingFlags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance |
                                                  System.Reflection.BindingFlags.IgnoreCase;

        private readonly IEnumerable<string> _propertyNames = new List<string>();


        private bool NoFieldsSpecified => !_propertyNames.Any();

        public PropertyInfoRefferences(string fileldsList)
        {
            if (string.IsNullOrWhiteSpace(fileldsList))
                return;
            _propertyNames = fileldsList.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim());
        }

        public ExpandoObject ExtractObjectWithRequiredPropertiesFrom(T sourceObject)
        {
            var dartashapperdObject = new ExpandoObject();

            foreach (var propertyinfo in GetTypeProperties())
            {
                var propertyValue = propertyinfo.GetValue(sourceObject);
                ((IDictionary<string, object>) dartashapperdObject).Add(propertyinfo.Name, propertyValue);
            }

            return dartashapperdObject;
        }

        private IEnumerable<PropertyInfo> GetTypeProperties()
        {
            if (NoFieldsSpecified)
                return ExtractAllPropertyInfos();

            var result = new List<PropertyInfo>();
            foreach (var field in _propertyNames)
            {
                var propertyInfo = typeof(T).GetProperty(field, BindingFlags);

                if (propertyInfo is null)
                    throw new Exception($"Property {field} wasn't found on {typeof(T)}");

                result.Add(propertyInfo);
            }

            return result;
        }

        private static IEnumerable<PropertyInfo> ExtractAllPropertyInfos() => typeof(T).GetProperties(BindingFlags);
    }
}
