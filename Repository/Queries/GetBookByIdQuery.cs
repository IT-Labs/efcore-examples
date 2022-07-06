using Contracts;
using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Queries
{
    public class GetBookByIdQuery : BaseQuery<IdRequest, Book>
    {
        public override IResult<Book> Execute(IContext dataContext)
        {
            var book = dataContext.AsQueryable<Book>()
                .Include(x => x.BookAuthor)
                    .ThenInclude(x => x.Author)
                .FirstOrDefault(x => x.Id == Request.Id);

            if (book == null)
            {
                return new Result<Book>(System.Net.HttpStatusCode.NotFound, $"{nameof(Book)} not found");
            }

            return new Result<Book>(book);
        }
    }
}
