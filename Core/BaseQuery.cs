using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class BaseQuery<TRequest, TResult> : IQuery<TRequest, TResult> where TRequest : IRequest
    {
        public TRequest Request { get; set; }
        public abstract IResult<TResult> Execute(IContext dataContext);
    }
}
