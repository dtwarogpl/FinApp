using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace FinApp.Api.Helpers.DataShaping
{
    public static class IDataShappingExtensions
    {
        public static IEnumerable<ExpandoObject> ShapeData<TSource>(this IEnumerable<TSource> source, string fieldsToExtract)
        {
            var properties = new PropertyInfoRefferences<TSource>(fieldsToExtract);
            return source.Select(x => properties.ExtractObjectWithRequiredPropertiesFrom(x));
        }

        public static ExpandoObject ShapeData<TSource>(this TSource source, string fieldsToExtract)
        {
            var properties = new PropertyInfoRefferences<TSource>(fieldsToExtract);
            return properties.ExtractObjectWithRequiredPropertiesFrom(source);
        }
    }
}
