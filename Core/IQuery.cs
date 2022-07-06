namespace Core
{
    public interface IQuery<TRequest, TResult> where TRequest : IRequest
    {
        IResult<TResult> Execute(IContext dataContext);
        TRequest Request { get; }
    }
}
