using System.Collections.Generic;
using System.Net;

namespace Core
{
    public class PagedResponse<T> : ListResponse<T>
    {
        public Meta Meta { get; set; } = new Meta();

        public static new PagedResponse<T> Forbidden(string message = "Forbidden action")
        {
            return new PagedResponse<T>
            {
                Status = HttpStatusCode.Forbidden,
                Messages = new List<string> { message }
            };
        }

        public static new PagedResponse<T> BadRequest(string message = "Bad request")
        {
            return new PagedResponse<T>
            {
                Status = HttpStatusCode.BadRequest,
                Messages = new List<string> { message }
            };
        }

        public static new PagedResponse<T> NotFound(string message = "Not Found")
        {
            return new PagedResponse<T>
            {
                Status = HttpStatusCode.NotFound,
                Messages = new List<string> { message }
            };
        }
    }
}
