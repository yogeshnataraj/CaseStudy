using CaseStudy.Application;
using CaseStudy.Application.Authentication;
using CaseStudy.Domain;
using CaseStudy.Contracts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfra(builder.Configuration);
    builder.Services.AddContract();
    builder.Services.AddDomain();
    builder.Services.AddControllers();
}

var app = builder.Build();{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

