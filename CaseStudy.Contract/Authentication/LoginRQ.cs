namespace CaseStudy.Contracts.Authentication;

public record LoginRQ
{
    public string Email { get; set;}
    public string Password { get; set;}    
}