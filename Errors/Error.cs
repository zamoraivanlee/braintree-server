using System.Text.Json.Serialization;

namespace BraintreeServer.Errors;

public class Error
{
    public string Type { get; }
    public string Title { get; }
    [JsonPropertyName("status")]
    public int StatusCode { get; }
    public IDictionary<string, string[]> Errors { get; }

    public Error(ErrorType type, string title, IDictionary<string, string[]> errors)
    {
        Type = type.GetDocumentationUrl();
        Title = title;
        StatusCode = (int)type;
        Errors = errors;
    }
}

public enum ErrorType : int
{
    BadRequest = 400,
    Unauthorized = 401,
    PaymentRequired = 402,
    Forbidden = 403,
    NotFound = 404,
    MethodNotAllowed = 405,
    NotAcceptable = 406,
    ProxyAuthenticationRequired = 407,
    RequestTimeout = 408,
    Conflict = 409,
    Gone = 410,
    LengthRequired = 411,
    PreconditionFailed = 412,
    PayloadTooLarge = 413,
    UriTooLong = 414,
    UnsupportedMediaType = 415,
    RangeNotSatisfiable = 416,
    ExpectationFailed = 417,
    UpgradeRequired = 426
}

public static class ErrorTypeExtension
{
    public static string GetDocumentationUrl(this ErrorType errorType)
    {
        switch (errorType)
        {
            case ErrorType.BadRequest:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            case ErrorType.Unauthorized:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-3.1";
            case ErrorType.PaymentRequired:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.2";
            case ErrorType.Forbidden:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3";
            case ErrorType.NotFound:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            case ErrorType.MethodNotAllowed:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.5";
            case ErrorType.NotAcceptable:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.6";
            case ErrorType.ProxyAuthenticationRequired:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-3.2";
            case ErrorType.RequestTimeout:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.7";
            case ErrorType.Conflict:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
            case ErrorType.Gone:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9";
            case ErrorType.LengthRequired:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.10";
            case ErrorType.PreconditionFailed:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-4.2";
            case ErrorType.PayloadTooLarge:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.11";
            case ErrorType.UriTooLong:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.12";
            case ErrorType.UnsupportedMediaType:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.13";
            case ErrorType.RangeNotSatisfiable:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-4.4";
            case ErrorType.ExpectationFailed:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.14";
            case ErrorType.UpgradeRequired:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.15";
            default:
                return "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        }
    }
}
