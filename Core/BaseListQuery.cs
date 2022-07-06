namespace Core
{
    public abstract class BaseListQuery<TRequest, TResult> : IListQuery<TRequest, TResult> where TRequest : IRequest
    {
        public TRequest Request { get; set; }
        public abstract IListResult<TResult> Execute(IContext dataContext);
    }
}
