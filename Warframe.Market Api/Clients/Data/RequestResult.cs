using System;

namespace Warframe.Market_Api.Api.Data
{
    public class RequestResult<T> where T : new()
    {
        public bool IsSuccess { get; private set; }
        public Exception Exception { get; private set; }
        public T Result { get; private set; }

        public static RequestResult<T> Success(T result) => new RequestResult<T> { IsSuccess = true, Exception = null, Result = result};
        public static RequestResult<T> Error(Exception exception) => new RequestResult<T> { IsSuccess = false, Exception = exception, Result = default };
    }
}
