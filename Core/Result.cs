using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core
{
    public class Result<TValue> : IResult<TValue>
    {

        public Result()
        {
            Errors = new List<string>();
            Status = HttpStatusCode.OK;
        }

        public Result(TValue v) : this()
        {
            Value = v;
        }

        public Result(HttpStatusCode status, string message = null)
        {
            Status = status;
            Errors = new List<string>();

            if (!string.IsNullOrEmpty(message))
            {
                Errors = new List<string>
                {
                    message
                };
            }
        }

        public HttpStatusCode Status { get; set; }

        public List<string> Errors { get; set; }

        public TValue Value { get; set; }
    }
}
