using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oakton;
using Travels.Api;
using Travels.Api.Extensions;
using Travels.Api.Middleware;
using Travels.Infrastructure;
using Travels.Infrastructure.Data;
using Travels.Infrastructure.Extensions;
using Wolverine;
using Wolverine.FluentValidation;
var builder = WebApplication.CreateSlimBuilder(args);

builder.Configuration.AddEnvironmentVariables(prefix: "Travels_");
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<TravelsContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Travels.Api")));
builder.Services.AddOptions();
builder.Services.ConfigureApiServices();
builder.Services.ConfigureInfrastructureServices();
builder.Host.UseWolverine(options =>
{
    options.Discovery.IncludeAssembly(typeof(Travels.Application.Extension).Assembly);
    options.Discovery.IncludeAssembly(typeof(Travels.Infrastructure.Extension).Assembly);
    options.Discovery.IncludeAssembly(typeof(Travels.Domain.Extension).Assembly);

    options.UseFluentValidation();
    options.UseFluentValidation(RegistrationBehavior.ExplicitRegistration);
});
var app = builder.Build();
app.UseMiddleware<ValidationExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseErrorHandler();
app.ConfigureApplicationSwagger();
//.MigrateDatabase();

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MercuriusContext>>();
//    var datebase = await db.CreateDbContextAsync();
//    await MercuriusContext.InitializeAsync(datebase);
//}
return await app.RunOaktonCommands(args);