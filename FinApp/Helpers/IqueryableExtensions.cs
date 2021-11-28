using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using FinApp.Api.Services;

namespace FinApp.Api.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy,
            Dictionary<string, PropertyMappingValue> mappingDictionary)

        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (mappingDictionary == null)
                throw new ArgumentNullException(nameof(mappingDictionary));
            if (string.IsNullOrWhiteSpace(orderBy))
                return source;

            var orderByAfterSplit = orderBy.Split(',');
            var orderByString = string.Empty;
            foreach (var orderbyClause in orderByAfterSplit.Reverse())
            {
                var trimOrderByClause = orderbyClause.Trim();

                var orderDescending = trimOrderByClause.EndsWith(" desc");

                var idndexOfFirstSpace = trimOrderByClause.IndexOf(" ");

                var propertyname = idndexOfFirstSpace == -1 ? trimOrderByClause : trimOrderByClause.Remove(idndexOfFirstSpace);

                if (!mappingDictionary.ContainsKey(propertyname))
                    throw new Exception($"Key mapping for {propertyname} is missing");

                var propertyMappingValue = mappingDictionary[propertyname];

                if (propertyMappingValue == null)
                    throw new ArgumentNullException(nameof(propertyMappingValue));

                foreach (var destinationProperty in propertyMappingValue.DestinationProperties)
                {
                    if (propertyMappingValue.Revert)
                        orderDescending = !orderDescending;

                    orderByString = orderByString + (string.IsNullOrWhiteSpace(orderByString) ? string.Empty : ", ") + destinationProperty +
                                    (orderDescending ? " descending" : " ascending");
                }
            }

            return source.OrderBy(orderByString);
        }
    }
}
