using Microsoft.AspNetCore.Mvc;

namespace apbd_cw7_EntityFramework.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PcsController : ControllerBase
{
    
    [HttpGet]
    public IActionResult GetPCs()
    {
        return Ok();
    }
}