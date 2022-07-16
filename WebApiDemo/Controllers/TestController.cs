using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers;

[ApiController]
public class TestController : ControllerBase
{
    // GET
    [Route("api/[controller]")]
    [HttpGet]
    public string Get(string name)
    {
        return "Hello, " + name;
    }
}