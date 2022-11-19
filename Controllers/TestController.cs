using BraintreeServer.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BraintreeServer.Controllers;

[ApiController]
public class TestController : ControllerBase
{
    private readonly TestConfiguration _configuration;

    public TestController(IOptions<TestConfiguration> configuration) => _configuration = configuration.Value;

    [HttpGet]
    [Route("test-amounts")]
    public ActionResult<IEnumerable<TestAmount>> GetAmounts() => Ok(_configuration.Amounts);

    [HttpGet]
    [Route("test-cards")]
    public ActionResult<IEnumerable<TestCard>> GetCards() => Ok(_configuration.Cards);
}