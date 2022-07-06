using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class BaseManager
    {
        protected readonly DomainRepository _repository;

        protected BaseManager(DomainRepository repository)
        {
            _repository = repository;
        }

        protected Response<TResult> ExecuteCustomQuery<TQuery, TRequest, TResult>(TRequest request)
            where TRequest : IRequest
            where TQuery : BaseQuery<TRequest, TResult>, new()
        {
            var response = new Response<TResult>();

            var query = new TQuery { Request = request };
            var result = _repository.ExecuteQuery(query);
            response.Merge(result);

            return response;
        }

        protected PagedResponse<TResult> ExecuteCustomListQuery<TQuery, TRequest, TResult>(TRequest request)
            where TRequest : IRequest
            where TQuery : BaseListQuery<TRequest, TResult>, new()
        {
            var response = new PagedResponse<TResult>();

            var query = new TQuery { Request = request };
            var result = _repository.ExecuteQuery(query);
            response.Merge(result);

            return response;
        }

        protected Response<TResult> ExecuteCustomCommand<TCommand, TRequest, TResult>(TRequest request)
            where TRequest : IRequest
            where TCommand : BaseCommand<TRequest, TResult>, new()
        {
            var response = new Response<TResult>();

            var command = new TCommand { Request = request };
            var result = _repository.ExecuteCommand(command);
            response.Merge(result);

            return response;
        }
    }
}
