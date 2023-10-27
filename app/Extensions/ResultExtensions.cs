
using App.Results;

namespace App.Extensions
{
    public static class ResultExtensions
    {
        public static Result<T> AsResult<T>(this T data)
        {
            return new Result<T>(data);
        }
    }
}