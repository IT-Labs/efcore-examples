using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core
{
    public class ListResult<TValue> : IListResult<TValue>
    {
        public ListResult(List<TValue> values)
        {
            Values = values;
            Total = Values?.Count ?? 0;
        }

        public ListResult(List<TValue> values, IPageRequest request) : this(values)
        {
            CurrentPage = request.CurrentPage;
            PageSize = request.PageSize;
            All = request.All;
        }

        public ListResult(HttpStatusCode status, string message = null)
        {
            Status = status;
            if (!string.IsNullOrEmpty(message))
            {
                Errors = new List<string>
                {
                    message
                };
            }
        }

        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;

        public List<string> Errors { get; set; } = new List<string>();

        public List<TValue> Values { get; set; } = new List<TValue>();

        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public bool All { get; set; }

        public int Total { get; set; }
    }
}
