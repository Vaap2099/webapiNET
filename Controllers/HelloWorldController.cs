using Microsoft.AspNetCore.Mvc;

namespace webapinet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorld)
    {
        helloWorldService = helloWorld;

    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }


}