using CaseStudy.Application.Authentication;

namespace CaseStudy.Application.Interfaces;
public interface IAuthenticationServices
{
    public AutheticationResponse Register(string firstname, string lastname, string email, string password);

    public AutheticationResponse Login(string email, string password);   
}


