namespace FinApp.Api.Helpers.Sorting.PropertyMappings
{
    public interface IPropertyMaping
    {
        PropertyMappingValue GetByKey(string key);
        bool IsValidFor(string propertyName);
    }
}
