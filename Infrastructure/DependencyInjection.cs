using Domain.Interfaces.Builders;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Repositories;
using Infrastructure.Builders;
using Infrastructure.Data;
using Infrastructure.Factories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Get Environment Variables
        var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
        var database = Environment.GetEnvironmentVariable("POSTGRES_DB");
        var username = Environment.GetEnvironmentVariable("POSTGRES_USER");
        var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

        // Build connection string
        var connectionString = $"Host={host};Database={database};Username={username};Password={password}";

        // Configure DbContext with the connection string
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        //Repositories
        services.AddScoped<ISourceDbRepository, SourceDbRepository>();
        services.AddScoped<IFormElementRepository, FormElementRepository>();
        services.AddScoped<IContactDataRepository, ContactDataRepository>();

        //Builders
        services.AddSingleton<IConnectionStringBuilder,ConnectionStringBuilder>();

        services.AddScoped<IConnectionStringDirector, ConnectionStringDirector>();
        
        //Factories
        services.AddScoped<IDataDbContextFactory,DataDbContextFactory>();

        //Cache
        services.AddMemoryCache();

        return services;
    }    
}