namespace Core
{
    public interface IRepository
    {
        IListResult<TResult> ExecuteQuery<TRequest, TResult>(IListQuery<TRequest, TResult> query) where TRequest : IRequest;
        IResult<TResult> ExecuteCommand<TRequest, TResult>(ICommand<TRequest, TResult> command) where TRequest : IRequest;
        IResult<TResult> ExecuteQuery<TRequest, TResult>(IQuery<TRequest, TResult> query) where TRequest : IRequest;
    }
}
