using CaseStudy.Api.ApiModles;
using CaseStudy.Application.Authentication;
using CaseStudy.Application.Interfaces;
using CaseStudy.Contracts.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private IAuthenticationServices _authenticationService;

    public AuthenticationController(IAuthenticationServices authenticationService) => _authenticationService = authenticationService;

    [HttpPost("register")]
    public IActionResult Register(RegisterRQ registerRQ)
    {
        var result = _authenticationService.Register(
            registerRQ.FirstName, 
            registerRQ.LastName,
            registerRQ.Email,
            registerRQ.Password);
        
        var response = new AuthenticationResponse{
            FirstName = result.FirstName,
            LastName = result.LastName,
            Token = result.Tokens,
            Email = result.Email,
            Password = result.Password,
        };

        return Ok(response);
    }

     [HttpPost("login")]
    public IActionResult Login(LoginRQ loginRQ)
    {
        return Ok(loginRQ);
    }
}        