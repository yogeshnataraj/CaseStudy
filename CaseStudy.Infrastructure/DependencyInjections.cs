using CaseStudy.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CaseStudy.Application;

public static class DependencyInjection
{
     public static IServiceCollection AddInfra(this IServiceCollection services)
     {
            return services;
     }
}