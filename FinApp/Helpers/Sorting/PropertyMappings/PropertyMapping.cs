using System;
using System.Collections.Generic;

namespace FinApp.Api.Helpers.Sorting.PropertyMappings
{
    public abstract class PropertyMapping<TSource, TDestination> : IPropertyMaping
    {
        private Dictionary<string, PropertyMappingValue> MapDictionary { get; } = new(StringComparer.OrdinalIgnoreCase);
        public PropertyMappingValue GetByKey(string key) => MapDictionary[key];
        public bool IsValidFor(string propertyName) => MapDictionary.ContainsKey(propertyName) && MapDictionary[propertyName] != null;

        protected void AddMapping(string propertyName, PropertyMappingValue mappingValue)
        {
            MapDictionary.Add(propertyName, mappingValue);
        }
    }
}
