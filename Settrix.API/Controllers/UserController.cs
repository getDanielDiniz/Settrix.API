using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Settrix.Application.UseCases.User.Create;
using Settrix.Application.UseCases.User.Login;
using Settrix.Comunication.DTO_s.Request;
using Settrix.Comunication.DTO_s.Response;

namespace Settrix.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("Register")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(ResponseLoggedUserJson))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(ResponseSettrixErrorJson))]
    [ProducesResponseType(statusCode: StatusCodes.Status409Conflict, type: typeof(ResponseSettrixErrorJson))]
    public async Task<IActionResult> RegisterUser([FromBody] RequestRegisterUserJson newUser,
        [FromServices] IRegisterUserUseCase useCase)
    {
        var response = await useCase.Execute(newUser);
        return Created(string.Empty, response);
    }
    
    [HttpPost("Login")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ResponseLoggedUserJson))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(ResponseSettrixErrorJson))]
    [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized, type: typeof(ResponseSettrixErrorJson))]
    public async Task<IActionResult> LoginUser([FromBody] RequestLoginCredentialsJson credentials,
        [FromServices] ILoginUseCase useCase)
    {
        var response = await useCase.Execute(credentials);
        return Ok(response);
    }
}
