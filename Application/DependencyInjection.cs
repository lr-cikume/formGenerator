using Application.HtmlGenerator;
using Application.HtmlGenerator.Builder;
using Application.Services;
using Domain.ConfigOptions;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IContactDataService, ContactDataService>();

        services.AddScoped<HtmlGeneratorService>();
        services.AddScoped<HtmlFactory>();
        services.AddScoped<InputBuilder>();

        services.Configure<HtmlGeneratorOptions>(configuration.GetSection("HtmlGenerator"));

        return services;
    }    
}