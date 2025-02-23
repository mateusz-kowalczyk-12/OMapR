using Microsoft.Extensions.DependencyInjection;
using OMapR.Application;
using OMapR.Application.Options;

namespace OMapR.Api.DependencyInjection;


public static class ServiceCollectionExtensions
{
    public static void AddOMapR(this IServiceCollection services, Action<OMapROptions> configureOptions)
    {
        var options = new OMapROptions();
        configureOptions(options);
        
        services.AddSingleton(options);
        services.AddSingleton<ICore, Core>();
        services.AddSingleton<IPersistenceProxy, PersistenceProxy>();
    }
}