namespace Braintree.Dtos;

public class CreateTransactionDto
{
    public decimal Amount { get; set; }
    public string Nonce { get; set; } = string.Empty;
    public string DeviceData { get; set; } = string.Empty;
    public string AuthenticationId { get; set; } = string.Empty;
}
