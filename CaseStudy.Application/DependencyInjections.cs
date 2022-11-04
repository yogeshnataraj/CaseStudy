using CaseStudy.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CaseStudy.Application;

public static class DependencyInjection
{
     public static IServiceCollection AddApplication(this IServiceCollection services)
     {
        services.AddScoped<IAuthenticationServices, AuthenticationServices>();
        return services;
     }
}