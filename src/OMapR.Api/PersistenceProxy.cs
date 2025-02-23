using OMapR.Application;
using OMapR.Application.EntityAccess;
using OMapR.Application.MappingConfigs;

namespace OMapR.Api;


public class PersistenceProxy : IPersistenceProxy
{
    private readonly ICore _core;

    
    public PersistenceProxy(ICore core)
    {
        _core = core;
    }
    
    public IEntityConfig<TEntity> AddEntityMapping<TEntity>()
        where TEntity : new()
    {
        return _core.AddEntityConfig<TEntity>();
    }

    public IEntityAccess<TEntity> AccessEntity<TEntity>()
        where TEntity : new()
    {
        return _core.GetEntityAccess<TEntity>();
    }
}