using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using FinApp.Api.Helpers.Sorting;
using FinApp.Api.Helpers.Sorting.PropertyMappings;

namespace FinApp.Api.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy, IPropertyMaping mapping)

        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (mapping == null)
                throw new ArgumentNullException(nameof(mapping));
            return string.IsNullOrWhiteSpace(orderBy) ? source : source.OrderBy(new SortString(orderBy, mapping));
        }
    }
}
