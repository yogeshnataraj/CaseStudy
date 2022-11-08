using System.Data.Common;
using CaseStudy.Application.Authentication;
using CaseStudy.Domain.Infra;
using CaseStudy.Domain.Interfaces;
using CaseStudy.Infrastructure.Data;
using CaseStudy.Infrastructure.Repositorys;
using CaseStudy.Infrastructure.RestClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaseStudy.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration Configuration)
    {
        var dbConnection = Configuration.GetSection("ConnectionStrings");

        services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase(databaseName: "CaseStudy"));

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IRestClient, RestClient>();

        return services;
    }
}