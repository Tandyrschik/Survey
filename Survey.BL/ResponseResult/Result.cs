
namespace Survey.BL.ResponseResult
{
    public class Result<TValue>
    {
        public readonly TValue? Value;

        public readonly int StatusCode;
        public readonly string? Message;
        private Result(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message;
        }

        private Result(TValue? value, int statusCode, string? message = null)
        {
            Value = value;
            StatusCode = statusCode;
            Message = message;
        }

        public static Result<TValue> NotFound(string? message = null)
        {
            return new(404, message);
        }

        public static Result<TValue> BadRequest(string? message = null)
        {
            return new(400, message);
        }

        public static Result<TValue> Ok(TValue? value, string? message = null)
        {
            return new(value, 200, message);
        }

        public static Result<TValue> Created(TValue? value, string? message = null)
        {
            return new(value, 201, message);
        }

        public static Result<TValue> NoContent(string? message = null)
        {
            return new(204, message);
        }
    }
}
