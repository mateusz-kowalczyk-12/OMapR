using OMapR.Api.DependencyInjection;
using OMapR.Showcase.Persistence;

namespace OMapR.Showcase;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                               ?? throw new ArgumentException("Connection string not found.");
        
        services.AddOMapR(
            options => options.UseSqlServer(connectionString),
            AppOMapRConfiguration.ConfigureMapping);
    }
}