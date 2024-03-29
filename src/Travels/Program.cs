using System;
using System.Linq;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using Travels.Infrastructure;
using Travels.Infrastructure.Data;
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


builder.Services.AddEndpointsApiExplorer();
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<TravelsContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Travels.Api")));
builder.Services.ConfigureApiServices();
builder.Services.AddProblemDetails();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddApiVersioning(
          options =>
          {
              options.DefaultApiVersion = new ApiVersion(1.0);
              options.AssumeDefaultVersionWhenUnspecified = true;
              options.ReportApiVersions = true;
              options.ApiVersionReader = ApiVersionReader.Combine(
                     new UrlSegmentApiVersionReader(),
                     new QueryStringApiVersionReader("api-version"),
                     //new HeaderApiVersionReader("X-Version"),
                     new MediaTypeApiVersionReader("x-version"));
          }).AddApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
// .EnableApiVersionBinding();
//builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
//builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo() { Title = "API V1", Version = "V1.0" });
    options.SwaggerDoc("V2", new OpenApiInfo() { Title = "API V2", Version = "V2.0" });
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    options.CustomSchemaIds(x => x.FullName);
}
);

builder.Services.AddControllers();
builder.Services.ConfigureInfrastructureServices();

var app = builder.Build();
//app.UseMiddleware<ValidationExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    //var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint($"/swagger/V1/swagger.json", "V1.0");
        options.SwaggerEndpoint($"/swagger/V2/swagger.json", "V2.0");
    });
}


return await app.RunOaktonCommands(args);
