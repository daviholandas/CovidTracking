using System;

namespace BoxTI.Challenge.CovidTracking.WebApi.Models
{
    public readonly struct Result<T>
    {
        public Result(T value)
        {
            Value = value;
            IsSuccess = true;
            Error = null;
        }

        public Result(Exception error)
        {
            Value = default(T);
            IsSuccess = false;
            Error = error;
        }
        public T? Value { get; }
        public bool IsSuccess { get; }
        public Exception Error { get; }

        public static implicit operator Result<T>(T value)
            => new Result<T>(value);
    }

    public readonly struct Result
    {
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
            Error = null;
        }

        public Result(Exception error)
        {
            IsSuccess = false;
            Error = error;
        }
        public bool IsSuccess { get; }
        public Exception Error { get; }

        public static Result<T> Success<T>(T value)
            => new Result<T>(value);
        public static Result<T> NotSuccess<T>(Exception error)
            => new Result<T>(error);

        public static Result NotSuccess(Exception error)
            => new Result(error);

        public static Result Success()
            => new Result(true);
    }
}