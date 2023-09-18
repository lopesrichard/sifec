using System.Diagnostics.CodeAnalysis;

namespace App.Results
{
    public class Result
    {
        [MemberNotNullWhen(false, nameof(Exception))]
        public bool Success { get; }

        public Exception? Exception { get; }

        public Result()
        {
            Success = true;
        }

        public Result(Exception exception)
        {
            Success = false;
            Exception = exception;
        }

        public static implicit operator Result(Exception exception) => new(exception);
    }

    public class Result<T>
    {
        [MemberNotNullWhen(true, nameof(Data))]
        [MemberNotNullWhen(false, nameof(Exception))]
        public bool Success { get; }

        public T? Data { get; }

        public Exception? Exception { get; }

        public Result(T data)
        {
            Success = true;
            Data = data;
        }

        public Result(Exception exception)
        {
            Success = false;
            Exception = exception;
        }

        public static implicit operator Result<T>(T data) => new(data);

        public static implicit operator Result<T>(Exception exception) => new(exception);
    }
}

