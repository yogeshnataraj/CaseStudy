using CaseStudy.Application;
using CaseStudy.Application.Authentication;
using CaseStudy.Contracts;
using CaseStudy.Domain;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddDomain();
    builder.Services.AddContract();    
    builder.Services.AddControllers();
}

var app = builder.Build();{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

