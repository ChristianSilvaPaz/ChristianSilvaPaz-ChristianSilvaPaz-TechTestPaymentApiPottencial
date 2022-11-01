using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Services;
using Sales.Domain.Services.Models;

namespace Sales.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userServices;

    public UserController(UserService userServices)
    {
        _userServices = userServices;
    }

    [HttpPost("auth")]
    public async Task<IActionResult> Auth(UserAutheticationModel model)
    {
        var result = await _userServices.Authenticate(model);

        if (result.Errors.Count > 0)
        {
            return BadRequest(result);
        }

        return Ok(result.Data);
    }
}
