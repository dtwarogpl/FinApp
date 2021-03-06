using System.Linq;
using FinApp.Helpers;

namespace FinApp.Api.Helpers
{
    public static class QueryableExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageNumber, int pageSize) =>
            PagedList<T>.Create(source, pageNumber, pageSize);
        
        public static PagedList<T> ToSinglePageList<T>(this IQueryable<T> source) =>
            SinglePageList<T>.Create(source);
    }
}
