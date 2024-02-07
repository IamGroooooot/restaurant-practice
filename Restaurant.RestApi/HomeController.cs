using Microsoft.AspNetCore.Mvc;

namespace Restaurant.RestApi;

public class HomeController : ControllerBase
{
    [Route("")]
    public IActionResult Get()
    {
        return Ok(new { message = "Hello, World!"});
    }
}