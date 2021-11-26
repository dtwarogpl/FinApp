using System.Collections.Generic;
using FinApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Api.Helpers.Pagination
{
    public class PaginationUriFactory
    {
        private readonly Dictionary<string, object> _resultElements = new();
        private readonly string _routeName;
        private readonly IUrlHelper _urlHelper;

        public PaginationUriFactory(IUrlHelper urlHelper, string routeName)
        {
            _urlHelper = urlHelper;
            _routeName = routeName;
        }

        public string CreatePaginationUri(IPaginationParameters paginationData, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link(_routeName, CreateResultObject(paginationData.PageNumber - 1, paginationData.PageSize));
                case ResourceUriType.NextPage:
                    return _urlHelper.Link(_routeName, CreateResultObject(paginationData.PageNumber + 1, paginationData.PageSize));
                default:
                    return _urlHelper.Link(_routeName, CreateResultObject(paginationData.PageNumber, paginationData.PageSize));
            }
        }

        private object CreateResultObject(int pageNumber, int pageSize)
        {
            AddOrUpdate(nameof(pageNumber), pageNumber);
            AddOrUpdate(nameof(pageSize), pageSize);
            return _resultElements;
        }

        private void AddOrUpdate(string name, object value)
        {
            if (_resultElements.ContainsKey(name))
                _resultElements[name] = value;
            else
                _resultElements.Add(name, value);
        }

        protected void Extend(string propertyName, object propertyValue)
        {
            _resultElements.Add(propertyName, propertyValue);
        }
    }
}
