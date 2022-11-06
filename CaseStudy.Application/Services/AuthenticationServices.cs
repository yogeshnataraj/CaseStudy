using CaseStudy.Application.Authentication;
using CaseStudy.Application.Interfaces;

namespace CaseStudy.Application.Services;

public class AuthenticationServices : IAuthenticationServices
{
    public AutheticationResponse Login(string email, string password)
    {
        return new AutheticationResponse(){
            FirstName = "username",
            LastName = "password",
            Tokens = "tokens"
        };
    }

    public AutheticationResponse Register(string firstname, string lastname, string email, string password)
    {
        //Generate user token using jwt 

        var userId = Guid.NewGuid();

        return new AutheticationResponse(){
            UserId = userId,
            FirstName = firstname,
            LastName = lastname,
            Email = email,
            Password = password,
            Tokens = "tokens"
        };
    }    
}

