using System.Linq;
using FinApp.Helpers;

namespace FinApp.Api.Helpers
{
    public static class QueryableExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageNumber, int pageSize) =>
            PagedList<T>.Create(source, pageNumber, pageSize);
    }
}
