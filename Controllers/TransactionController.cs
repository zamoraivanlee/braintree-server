using Braintree;
using Braintree.Dtos;
using Braintree.Services;
using Microsoft.AspNetCore.Mvc;

namespace BraintreeServer.Controllers;

[ApiController]
[Route("transactions")]
public class TransactionController : ControllerBase
{
    private readonly IBraintreeService _service;

    public TransactionController(IBraintreeService service) => _service = service;

    [HttpPost]
    public async Task<ActionResult<Transaction>> CreateTransaction(CreateTransactionDto dto) => Ok(await _service.CreateTransaction(dto.Amount, dto.Nonce, dto.DeviceData, dto.AuthenticationId));
}