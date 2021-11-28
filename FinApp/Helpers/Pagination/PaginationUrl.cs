using System.Collections.Generic;
using FinApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Api.Helpers.Pagination
{
    public class PaginationUrl
    {
        private readonly Dictionary<string, object> _resultElements = new();
        private readonly string _routeName;
        private readonly IUrlHelper _urlHelper;

        public PaginationUrl(IUrlHelper urlHelper, string routeName)
        {
            _urlHelper = urlHelper;
            _routeName = routeName;
        }

        public string GetCurrentPageUri(IPaginationParameters pagination) =>
            _urlHelper.Link(_routeName, CreateResultObject(pagination.PageNumber, pagination.PageSize));

        public string GetPreviousPageUri(IPaginationParameters pagination) =>
            _urlHelper.Link(_routeName, CreateResultObject(pagination.PageNumber - 1, pagination.PageSize));

        public string GetNextPageUri(IPaginationParameters pagination) =>
            _urlHelper.Link(_routeName, CreateResultObject(pagination.PageNumber + 1, pagination.PageSize));

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
