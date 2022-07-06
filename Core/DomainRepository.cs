using System;
using System.Net;

namespace Core
{
    public abstract class DomainRepository : IRepository, IDisposable
    {
        private readonly IContext _dataContext;

        protected DomainRepository(IContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual IResult<TResult> ExecuteCommand<TRequest, TResult>(ICommand<TRequest, TResult> command) where TRequest : IRequest
        {
            IResult<TResult> result = null;

            try
            {
                result = command.Execute(_dataContext);
            }
            catch (Exception exception)
            {
                result = HandleException(result, exception);
            }

            return result;
        }

        public virtual IResult<TResult> ExecuteQuery<TRequest, TResult>(IQuery<TRequest, TResult> query) where TRequest : IRequest
        {
            IResult<TResult> result = null;

            try
            {
                result = query.Execute(_dataContext);
            }
            catch (Exception exception)
            {
                result = HandleException(result, exception);
            }

            return result;
        }

        public virtual IListResult<TResult> ExecuteQuery<TRequest, TResult>(IListQuery<TRequest, TResult> query) where TRequest : IRequest
        {
            IListResult<TResult> result = null;

            try
            {
                result = query.Execute(_dataContext);
            }
            catch (Exception exception)
            {
                result = HandleException(result, exception);
            }

            return result;
        }

        private IResult<TResult> HandleException<TResult>(IResult<TResult> result, Exception exception)
        {
            if (result == null)
            {
                result = new Result<TResult>();
            }

            result.Status = HttpStatusCode.InternalServerError;
            result.Errors.Add(exception.Message);
            return result;
        }

        private IListResult<TResult> HandleException<TResult>(IListResult<TResult> result, Exception exception)
        {
            if (result == null)
            {
                result = new ListResult<TResult>(null);
            }

            result.Status = HttpStatusCode.InternalServerError;
            result.Errors.Add(exception.Message);
            return result;
        }

        public void Dispose()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
            }
        }
    }
}
