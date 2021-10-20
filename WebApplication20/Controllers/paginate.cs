using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.Controllers
{
    public  class paginate
    {
        public static PagedData<T> PagedResult<T>( IEnumerable<T> list, int PageNumber, int PageSize) where T : class
        {
            var result = new PagedData<T>();
            result.Data = list.Skip(PageSize * (PageNumber - 1)).Take(PageSize).ToList();
            result.TotalPages = Convert.ToInt32(Math.Ceiling((double)list.Count() / PageSize));
            result.CurrentPage = PageNumber;
            return result;
        }

        public class PagedData<T> where T : class
        {
            public IEnumerable<T> Data { get; set; }
            public int TotalPages { get; set; }
            public int CurrentPage { get; set; }
        }
    }
}


