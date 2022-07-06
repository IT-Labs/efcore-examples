namespace Core
{
    public interface IListQuery<TRequest, TResult> where TRequest : IRequest
    {
        IListResult<TResult> Execute(IContext dataContext);
        TRequest Request { get; }
    }
}
