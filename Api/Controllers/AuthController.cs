using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly Auth.IAuthRepository _authRepository;

    public AuthController(Auth.IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        var result = _authRepository.Login(loginRequest.UserName,loginRequest.Password);
        return string.IsNullOrEmpty(result) ? Ok(new { Token = result}) : BadRequest(result);
    }
    
    
    public sealed record LoginRequest(string UserName, string Password);
}