using System;
using System.Collections.Generic;
using System.Linq;
using FinApp.Api.Models;

namespace FinApp.Api.Services
{
    public interface IPropertyMappingService
    {
        Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();

        bool ValidMappingExistsFor<TSource, TDestination>(string fields);
    }

    public class PropertyMappingService : IPropertyMappingService
    {
        private readonly Dictionary<string, PropertyMappingValue> _expensePropertyMapping = new(StringComparer.OrdinalIgnoreCase)
        {
            {"Id", new PropertyMappingValue(new List<string> {"Id"})},
            {"Date", new PropertyMappingValue(new List<string> {"OccuredAt"})},
            {"PaidAmount", new PropertyMappingValue(new List<string> {"PaidAmount"})},
            {"ConsumptionAmount", new PropertyMappingValue(new List<string> {"ConsumptionAmount"})},
            {"ConsumptionTypeId", new PropertyMappingValue(new List<string> {"ConsumptionTypeId"})}
        };

        private readonly IList<IPropertyMaping> _propertyMapings = new List<IPropertyMaping>();

        public PropertyMappingService()
        {
            _propertyMapings.Add(new PropertyMapping<ExpenseDto, Expense>(_expensePropertyMapping));
        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            var matchinTypes = _propertyMapings.OfType<PropertyMapping<TSource, TDestination>>();

            if (matchinTypes.Count() == 1)
                return matchinTypes.First().MapDictionary;

            throw new Exception($"Cannot find exact property mapping instance for <{typeof(TSource)},{typeof(TDestination)}>");
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            if (string.IsNullOrWhiteSpace(fields))
                return true;

            // the string is separated by ",", so we split it.
            var fieldsAfterSplit = fields.Split(',');

            // run through the fields clauses
            foreach (var field in fieldsAfterSplit)
            {
                // trim
                var trimmedField = field.Trim();

                // remove everything after the first " " - if the fields 
                // are coming from an orderBy string, this part must be 
                // ignored
                var indexOfFirstSpace = trimmedField.IndexOf(" ");
                var propertyName = indexOfFirstSpace == -1 ? trimmedField : trimmedField.Remove(indexOfFirstSpace);

                // find the matching property
                if (!propertyMapping.ContainsKey(propertyName))
                    return false;
            }

            return true;
        }
    }

    public interface IPropertyMaping
    { }

    public class PropertyMapping<Tsource, Tdestination> : IPropertyMaping
    {
        public Dictionary<string, PropertyMappingValue> MapDictionary { get; }

        public PropertyMapping(Dictionary<string, PropertyMappingValue> mapDictionary) => MapDictionary = mapDictionary;
    }

    public class PropertyMappingValue
    {
        public IEnumerable<string> DestinationProperties { get; }

        public bool Revert { get; }

        public PropertyMappingValue(IEnumerable<string> destinationProperties, bool revert = false)
        {
            DestinationProperties = destinationProperties ?? throw new ArgumentNullException(nameof(destinationProperties));
            Revert = revert;
        }
    }
}
