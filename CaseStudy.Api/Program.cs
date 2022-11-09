using CaseStudy.Application;
using CaseStudy.Application.Authentication;
using CaseStudy.Domain;
using CaseStudy.Contracts;
using CaseStudy.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddDomain();
    builder.Services.AddInfra(builder.Configuration);
    builder.Services.AddContract();
    builder.Services.AddControllers();
    builder.Services.AddMemoryCache(options => {
        options.ExpirationScanFrequency = TimeSpan.FromDays(1);
    });
}

var app = builder.Build();
{
    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseMiddleware<ExceptionMessageMiddleware1>();
    app.MapControllers();
    app.Run();
}

