using System;
using System.Collections.Generic;
using System.Linq;

namespace FinApp.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int PageSize { get; }
        public int TotalCount { get; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        private PagedList(List<T> items, int count, int pageNumber, int pagesize)
        {
            TotalCount = count;
            PageSize = pagesize;
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (double) pagesize);
            AddRange(items);
        }

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = GetPage(source, pageNumber, pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        private static IQueryable<T> GetPage(IQueryable<T> source, int pageNumber, int pageSize) =>
            source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}
