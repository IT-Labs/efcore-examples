using Contracts;
using Contracts.Requests;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Command
{
    public class SaveBookCommand : BaseCommand<SaveBookRequest, int>
    {
        public override IResult<int> Execute(IContext dataContext)
        {
            var query = dataContext.AsQueryable<Book>();

            var book = Request.IsNew()
                ? new Book()
                : query.FirstOrDefault(x => x.Id == Request.GetId());

            if (book == null)
            {
                return new Result<int>(System.Net.HttpStatusCode.NotFound, "Book not found");
            }

            var author = dataContext.AsQueryable<Author>().FirstOrDefault(x => x.Id == Request.AuthorId);
            if (author == null)
            {
                return new Result<int>(System.Net.HttpStatusCode.NotFound, "Author not found");
            }

            book.Name = Request.Name;
            book.BookAuthor.Add(new BookAuthor
            {
                Author = author
            });

            if (Request.IsNew())
            {
                dataContext.Insert(book);
            }
            else
            {
                dataContext.Update(book);
            }

            return new Result<int>(book.Id);
        }
    }
}
