using System.Collections.Generic;
using System.Linq;

namespace FinApp.Helpers
{
    public class SinglePageList<T> : PagedList<T>
    {
        public static PagedList<T> Create(IQueryable<T> source) 
        {
            var items = source.ToList();
            return new SinglePageList<T>(items);
        }

        protected SinglePageList(List<T> items) : base(items, items.Count, 1, items.Count)
        {
        }
    }
}