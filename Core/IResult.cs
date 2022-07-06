using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core
{
    public interface IResult<TValue> : IResult
    {
        TValue Value { get; set; }
    }

    public interface IResult
    {
        HttpStatusCode Status { get; set; }
        List<string> Errors { get; set; }
    }
}
