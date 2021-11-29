using System;
using System.Collections.Generic;
using System.Linq;

namespace FinApp.Api.Helpers.Sorting.PropertyMappings
{
    public class MappingSelector : IPropertyMappingService
    {
        private readonly IList<IPropertyMaping> _propertyMapings = new List<IPropertyMaping>();

        public MappingSelector(IEnumerable<IPropertyMaping> sources)
        {
            foreach (var source in sources)
                _propertyMapings.Add(source);
        }

        public IPropertyMaping GetPropertyMapping<TSource, TDestination>()
        {
            var matchinTypes = _propertyMapings.OfType<PropertyMapping<TSource, TDestination>>();

            if (matchinTypes.Count() == 1)
                return matchinTypes.First();

            throw new Exception($"Cannot find exact property mapping instance for <{typeof(TSource)},{typeof(TDestination)}>");
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields, out string errorMessage)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();
            var sortString = new SortString(fields, propertyMapping);


            if (string.IsNullOrWhiteSpace(fields) || sortString.IsValid(out var msg))
            {
                errorMessage = default;
                return true;
            }

            errorMessage = msg;
            return true;
        }
    }
}
