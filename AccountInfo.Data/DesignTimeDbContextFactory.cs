using System;
using System.IO;
using AccountInfo.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AccountInfo.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppInfoDbContext>
    {
        public AppInfoDbContext CreateDbContext(string[] args)
        {
            // Use current directory so dotnet-ef can find appsettings when run from the solution root
            var basePath = Directory.GetCurrentDirectory();

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            // Prefer a named connection string, then env var, then a local fallback
            var cs = config.GetConnectionString("AppInfoDb")
                  ?? Environment.GetEnvironmentVariable("ConnectionStrings__AppInfoDb")
                  ?? "Host=localhost;Database=appinfo;Username=postgres;Password=postgres";

            var optionsBuilder = new DbContextOptionsBuilder<AppInfoDbContext>();
            optionsBuilder.UseNpgsql(cs);

            return new AppInfoDbContext(optionsBuilder.Options);
        }
    }
}