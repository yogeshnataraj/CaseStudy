using Microsoft.Extensions.DependencyInjection;

namespace CaseStudy.Contracts;

public static class DependencyInjection
{
     public static IServiceCollection AddContract(this IServiceCollection services)
     {        
        return services;
     }
}