using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IListResult<TValue> : IListResult
    {
        List<TValue> Values { get; set; }
    }

    public interface IListResult : IResult, IPageResponse
    {
        int Total { get; set; }
    }
}
