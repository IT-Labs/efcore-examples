namespace Core
{
    public abstract class BaseCommand<TRequest, TResult> : ICommand<TRequest, TResult> where TRequest : IRequest
    {
        public TRequest Request { get; set; }
        public abstract IResult<TResult> Execute(IContext dataContext);
    }
}
