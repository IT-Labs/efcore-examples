using Contracts;
using Contracts.Managers;
using Contracts.Requests;
using Core;
using Repository.Command;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BookManager : BaseManager, IBookManager
    {
        public BookManager(DomainRepository repository) : base(repository)
        {

        }

        public Response<Book> Get(int id)
        {
            var request = new IdRequest(id);
            return ExecuteCustomQuery<GetBookByIdQuery, IdRequest, Book>(request);
        }

        public PagedResponse<Book> Get(PageRequest reqest)
        {
            return ExecuteCustomListQuery<GetBooksQuery, PageRequest, Book>(reqest);
        }

        public Response<int> Save(SaveBookRequest request)
        {
            return ExecuteCustomCommand<SaveBookCommand, SaveBookRequest, int>(request);
        }
    }
}
