using BraintreeServer.Errors;

namespace BraintreeServer.Exceptions;

public class BadRequestException : HttpException
{
    public BadRequestException(string title, IDictionary<string, string[]> errors) : base(ErrorType.BadRequest, title, errors) { }
}
