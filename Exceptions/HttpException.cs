using BraintreeServer.Errors;

namespace BraintreeServer.Exceptions;

public class HttpException : Exception
{
    public HttpException(int statusCode) => StatusCode = statusCode;

    public HttpException(Error error) => (StatusCode, Value) = (error.StatusCode, error);

    public HttpException(ErrorType type, string title, IDictionary<string, string[]> errors) => (StatusCode, Value) = ((int)type, new Error(type, title, errors));

    public int StatusCode { get; }
    public Error? Value { get; }
}
