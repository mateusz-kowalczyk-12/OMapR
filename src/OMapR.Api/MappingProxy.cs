using OMapR.Application;
using OMapR.Application.MappingConfigs;

namespace OMapR.Api;

public class MappingProxy
{
    private readonly Core _core;


    public MappingProxy(Core core)
    {
        _core = core;
    }
    
    public IEntityConfig<TEntity> AddEntityMapping<TEntity>()
        where TEntity : new()
    {
        return _core.AddEntityConfig<TEntity>();
    }
}