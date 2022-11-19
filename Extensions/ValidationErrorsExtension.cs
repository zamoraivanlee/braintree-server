using Braintree;

namespace BraintreeServer.Helpers;

public static class ValidationErrorsExtension
{
    public static IDictionary<string, string[]> Parse(this ValidationErrors validationErrors)
    {
        var errors = new Dictionary<string, string[]>();

        validationErrors.All().ForEach(error =>
        {
            var messages = errors[error.Attribute] ?? new string[] { };

            messages.Append(error.Message);

            errors[error.Attribute] = messages;
        });

        return errors;
    }
}
