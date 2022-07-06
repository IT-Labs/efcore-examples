using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core
{
    public class Response<T> : IResponse<T>
    {
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        public bool NotOk => Status != HttpStatusCode.OK;

        public List<string> Messages { get; set; } = new List<string>();

        public T Payload { get; set; } = default(T);

        public static Response<T> Forbidden(string message = "Forbidden action")
        {
            return new Response<T>
            {
                Status = HttpStatusCode.Forbidden,
                Messages = new List<string> { message }
            };
        }

        public static Response<T> BadRequest(string message = "Bad request")
        {
            return new Response<T>
            {
                Status = HttpStatusCode.BadRequest,
                Messages = new List<string> { message }
            };
        }

        public static Response<T> NotFound(string message = "Not Found")
        {
            return new Response<T>
            {
                Status = HttpStatusCode.NotFound,
                Messages = new List<string> { message }
            };
        }
    }

    public interface IResponse
    {
        HttpStatusCode Status { get; set; }

        List<string> Messages { get; set; }
    }

    public interface IResponse<T> : IResponse
    {
        T Payload { get; set; }
    }
}
