using Contracts;
using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Queries
{
    public class GetBooksQuery : BaseListQuery<PageRequest, Book>
    {
        public override IListResult<Book> Execute(IContext dataContext)
        {
            var query = dataContext.AsQueryable<Book>()
                .Include(x => x.BookAuthor)
                    .ThenInclude(x => x.Author);

            var total = query.Count();

            var data = Request.All
                ? query.ToList()
                : query.Skip((Request.CurrentPage - 1) * Request.PageSize).Take(Request.PageSize).ToList();

            return new ListResult<Book>(data)
            {
                CurrentPage = Request.All ? 1 : Request.CurrentPage,
                PageSize = Request.All ? total : Request.PageSize,
                All = Request.All,
                Total = total
            };
        }
    }
}
