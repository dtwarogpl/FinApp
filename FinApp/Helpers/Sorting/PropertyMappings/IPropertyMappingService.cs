namespace FinApp.Api.Helpers.Sorting.PropertyMappings
{
    public interface IPropertyMappingService
    {
        IPropertyMaping GetPropertyMapping<TSource, TDestination>();

        bool ValidMappingExistsFor<TSource, TDestination>(string fields, out string errorMessage);
    }
}
