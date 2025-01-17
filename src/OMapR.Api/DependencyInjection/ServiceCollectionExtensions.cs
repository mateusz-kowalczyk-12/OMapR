using Microsoft.Extensions.DependencyInjection;
using OMapR.Application;
using OMapR.Application.Common.Enums;
using OMapR.Application.Options;

namespace OMapR.Api.DependencyInjection;


public static class ServiceCollectionExtensions
{
    public static void AddOMapR(this IServiceCollection services, Action<OMapROptions> configureOptions)
    {
        var options = new OMapROptions();
        configureOptions(options);
        
        var core = new Core(options);
        
        services.AddSingleton<IPersistenceProxy>(_ => new PersistenceProxy(core));
    }
}