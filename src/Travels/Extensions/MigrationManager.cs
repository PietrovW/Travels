﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Travels.Infrastructure.Data;

namespace Travels.Api.Extensions;
//    CreateHostBuilder(args).Build().MigrateDatabase().Run();
public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            using var appContext = scope.ServiceProvider.GetRequiredService<TravelsContext>();
                try
                {
                    appContext.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    //Log errors or do anything you think it's needed
                    throw;
                }
        }
        return host;
    }
}
