using System;
using System.Linq;
using Asp.Versioning;
using Asp.Versioning.Conventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Oakton;
using Swashbuckle.AspNetCore.SwaggerGen;
using Travels.Api;
using Travels.Api.Extensions;
using Travels.Api.Middleware;
using Travels.Infrastructure;
using Travels.Infrastructure.Data;
using Travels.Infrastructure.Extensions;
using Wolverine;
using Wolverine.FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWolverine(options =>
{
    options.Discovery.IncludeAssembly(typeof(Travels.Application.Extension).Assembly);
    options.Discovery.IncludeAssembly(typeof(Travels.Infrastructure.Extension).Assembly);
    options.Discovery.IncludeAssembly(typeof(Travels.Domain.Extension).Assembly);
    options.UseFluentValidation();
    options.UseFluentValidation(RegistrationBehavior.ExplicitRegistration);
});

builder.Configuration.AddEnvironmentVariables(prefix: "Travels_");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
    setup.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<TravelsContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Travels.Api")));
builder.Services.ConfigureApiServices();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(
          options =>
          {
              options.DefaultApiVersion = new ApiVersion(1.0);
              options.AssumeDefaultVersionWhenUnspecified = true;
              // reporting api versions will return the headers
              // "api-supported-versions" and "api-deprecated-versions"
              options.ReportApiVersions = true;
              options.ApiVersionReader = ApiVersionReader.Combine(
                     new UrlSegmentApiVersionReader(),
                     new QueryStringApiVersionReader("api-version"),
                     new HeaderApiVersionReader("X-Version"),
                     new MediaTypeApiVersionReader("x-version"));
          })
            .AddMvc(
                options =>
                {
                    // automatically applies an api version based on the name of
                    // the defining controller's namespace
                    options.Conventions.Add(new VersionByNamespaceConvention());
                })
            .AddApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
        // this enables binding ApiVersion as a endpoint callback parameter. if you don't use it, then
        // you should remove this configuration.
       // .EnableApiVersionBinding();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
////builder.Services.AddSwaggerGen(options =>
////{
////    //options.OperationFilter<SwaggerDefaultValues>();
////    options.SwaggerDoc("V1", new OpenApiInfo() { Title = "API V1", Version = "V1.0" });
////    //options.SwaggerDoc("V2", new OpenApiInfo() { Title = "API V2", Version = "V2.0" });
////    // options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
////    //options.CustomSchemaIds(x => x.FullName);
////}
////);\
builder.Services.AddSwaggerGen((options =>
{
    options.SwaggerDoc("1.0", new OpenApiInfo
    {
        Version = "Version 1",
        Title = "Test API V1",
        Description = "An ASP.NET Core Web API for testing versioning"
    });

    options.SwaggerDoc("2.0", new OpenApiInfo
    {
        Version = "Version 2",
        Title = "Test API V2",
        Description = "An ASP.NET Core Web API for testing versioning"
    });
}));
builder.Services.ConfigureInfrastructureServices();

var app = builder.Build();
//app.MapControllers();
//app.UseErrorHandler();
//app.UseHttpsRedirection();
//app.UseRouting();

//app.UseMiddleware<ValidationExceptionMiddleware>();

   // app.UseDeveloperExceptionPage();
    // app.ConfigureApplicationSwagger();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint($"/swagger/swagger.json", "V1.0");
    
});




return await app.RunOaktonCommands(args);
