namespace Core
{
    public interface ICommand<TRequest, TResult> where TRequest : IRequest
    {
        IResult<TResult> Execute(IContext dataContext);
        TRequest Request { get; set; }
    }
}
