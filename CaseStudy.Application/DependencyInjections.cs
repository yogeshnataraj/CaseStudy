using CaseStudy.Application.Interfaces;
using CaseStudy.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CaseStudy.Application;

public static class DependencyInjection
{
     public static IServiceCollection AddApplication(this IServiceCollection services)
     {
        services.AddScoped<IAuthenticationServices, AuthenticationServices>();
        services.AddScoped<IProductServices, ProductServices>();
        return services;
     }
}