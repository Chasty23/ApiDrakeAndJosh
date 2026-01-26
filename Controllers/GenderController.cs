using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenderController : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok("Hello genders");
    }

}








