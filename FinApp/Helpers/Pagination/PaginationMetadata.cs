using System.Text.Json;
using FinApp.Api.Models;
using FinApp.Helpers;
using Microsoft.AspNetCore.Http;

namespace FinApp.Api.Helpers.Pagination
{
    public class PaginationMetadata<T>
    {
        private readonly PagedList<T> _elements;
        private readonly IPaginationParameters _paginationParameters;
        private readonly PaginationUrl _paginationUrl;

        public PaginationMetadata(IPaginationParameters paginationParameters, PagedList<T> elements, PaginationUrl paginationUrl)
        {
            _paginationParameters = paginationParameters;
            _elements = elements;
            _paginationUrl = paginationUrl;
        }

        public void AddTo(IHeaderDictionary headers)
        {
            var previousPageLink = PreviousPageLink(_paginationParameters, _elements);
            var nextPageLink = NextPageLink(_paginationParameters, _elements);

            var paginationMetadata = new
            {
                totalCount = _elements.TotalCount,
                pageSize = _elements.PageSize,
                currentPage = _elements.CurrentPage,
                totalPages = _elements.TotalPages,
                previousPageLink,
                nextPageLink
            };

            headers.Add(Constants.PaginationHeaderName, JsonSerializer.Serialize(paginationMetadata, new JsonSerializerOptions
            {
                IgnoreNullValues = true
            }));
        }

        private string NextPageLink(IPaginationParameters expensesResourceParameters, PagedList<T> expenses) =>
            expenses.HasNext ? _paginationUrl.GetNextPageUri(expensesResourceParameters) : null;

        private string PreviousPageLink(IPaginationParameters expensesResourceParameters, PagedList<T> expenses) =>
            expenses.HasPrevious ? _paginationUrl.GetPreviousPageUri(expensesResourceParameters) : null;
    }
}
