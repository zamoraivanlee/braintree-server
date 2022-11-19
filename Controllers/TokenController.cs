using Braintree.Services;
using Microsoft.AspNetCore.Mvc;

namespace BraintreeServer.Controllers;

[ApiController]
[Route("tokens")]
public class TokenController : ControllerBase
{
    private readonly IBraintreeService _service;

    public TokenController(IBraintreeService service) => _service = service;

    [HttpGet]
    [Route("new")]
    public ActionResult<string> GetNewToken() => Ok(_service.GetToken());
}