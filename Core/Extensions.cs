using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class Extensions
    {
        public static void Merge<T>(this IResponse<T> originalResponse, IResult<T> result)
        {
            if (result == null) return;
            originalResponse.Status = result.Status;
            originalResponse.Messages.AddRange(result.Errors);

            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                originalResponse.Payload = result.Value;
            }
        }

        public static void Merge<T>(this PagedResponse<T> originalResponse, IListResult<T> result)
        {
            if (result == null) return;
            originalResponse.Status = result.Status;
            originalResponse.Messages.AddRange(result.Errors);

            if (result.Status != System.Net.HttpStatusCode.OK)
            {
                return;
            }
            originalResponse.Payload = result.Values;
            originalResponse.Meta.TotalCount = result.Total;
            originalResponse.Meta.PageSize = result.PageSize;
            originalResponse.Meta.CurrentPage = result.CurrentPage;
            originalResponse.Meta.All = result.All;
        }
    }
}
