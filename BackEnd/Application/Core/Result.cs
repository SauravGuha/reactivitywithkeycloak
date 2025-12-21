

namespace Application.Core
{
    /// <summary>
    /// Common response model from mediatr
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        public bool IsSuccess { get; set; }

        public int ErrorCode { get; set; }

        public string? Error { get; set; }

        public T? Value { get; set; }

        public static Result<T> SetSuccess(T value) => new Result<T> { IsSuccess = true, Value = value };

        public static Result<T> SetFailure(int errorCode, string? error) => new Result<T> { IsSuccess = false, Error = error, ErrorCode = errorCode };
    }
}