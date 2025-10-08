using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class DirectoryController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Ok.");
    }
}