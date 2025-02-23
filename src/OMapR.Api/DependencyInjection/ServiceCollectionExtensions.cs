using Microsoft.Extensions.DependencyInjection;
using OMapR.Application;
using OMapR.Application.MappingConfigs;
using OMapR.Application.Options;

namespace OMapR.Api.DependencyInjection;


public static class ServiceCollectionExtensions
{
    public static void AddOMapR<TMappingConfigurator>(
        this IServiceCollection services, Action<OMapROptions> configureOptions)
        where TMappingConfigurator : IMappingConfigurator, new()
    {
        var options = new OMapROptions();
        configureOptions(options);
        services.AddSingleton(options);

        var mappingConfig = new MappingConfig();
        services.AddSingleton(mappingConfig);

        var core = new Core(options, mappingConfig);
        services.AddSingleton(core);

        var mappingProxy = new MappingProxy(core);
        var mappingConfigurator = new TMappingConfigurator();
        mappingConfigurator.Configure(mappingProxy);
        
        services.AddSingleton<PersistenceProxy>();
    }
}