using BraintreeServer.Configurations;
using BraintreeServer.Errors;
using BraintreeServer.Exceptions;
using BraintreeServer.Helpers;
using Microsoft.Extensions.Options;

namespace Braintree.Services;

public class BraintreeService : IBraintreeService
{
    private readonly BraintreeGateway _gateway;

    public BraintreeService(IOptions<BraintreeConfiguration> configuration)
    {
        _gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.ParseEnvironment(configuration.Value.Environment),
            MerchantId = configuration.Value.MerchantId,
            PublicKey = configuration.Value.PublicKey,
            PrivateKey = configuration.Value.PrivateKey
        };
    }

    public async Task<Transaction> CreateTransaction(decimal amount, string nonce, string deviceData)
    {
        var request = new TransactionRequest
        {
            Amount = amount,
            PaymentMethodNonce = nonce,
            DeviceData = deviceData,
            Options = new TransactionOptionsRequest
            {
                SubmitForSettlement = true
            }
        };

        var result = await _gateway.Transaction.SaleAsync(request);

        if (!result.IsSuccess()) throw new BadRequestException(result.Message, result.Errors.Parse());

        return result.Target;
    }

    public string GetToken() => _gateway.ClientToken.Generate();
}

public interface IBraintreeService
{
    Task<Transaction> CreateTransaction(decimal amount, string nonce, string deviceData);
    string GetToken();
}