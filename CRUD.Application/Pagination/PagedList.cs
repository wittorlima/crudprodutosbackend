using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Application.Pagination
{
    public class PagedList<T> : IPagedList<T>
    {
        public PagedList()
        {
            this.Data = new List<T>();
        }

        public PagedList(IEnumerable<T> enumerable, long pageNumber, long pageSize, long totalResults)
        {
            this.Data = enumerable.ToList();
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalResults = totalResults;
        }

        public IList<T> Data { get; set; }

        public long PageNumber { get; set; }

        public long PageSize { get; set; }

        public long TotalResults { get; set; }

        public long TotalPages
        {
            get
            {
                return PageSize == 0 ? 1 : (long)Math.Ceiling((double)TotalResults / PageSize);
            }
        }
    }
}