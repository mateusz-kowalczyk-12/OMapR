using Microsoft.Extensions.DependencyInjection;
using OMapR.Application;
using OMapR.Application.MappingConfigs;
using OMapR.Application.Options;

namespace OMapR.Api.DependencyInjection;


public static class ServiceCollectionExtensions
{
    public static void AddOMapR(
        this IServiceCollection services, Action<OMapROptions> configureOptions, Action<MappingConfigurator> mapEntities)
    {
        var options = new OMapROptions();
        configureOptions(options);
        services.AddSingleton(options);

        var mappingConfig = new MappingConfig();
        services.AddSingleton(mappingConfig);
        
        var core = new Core(options, mappingConfig);
        services.AddSingleton(core);

        var mappingProxy = new MappingConfigurator(core);
        mapEntities(mappingProxy);
        
        services.AddSingleton<PersistenceProxy>();
    }
}