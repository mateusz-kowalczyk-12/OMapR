using OMapR.Application;
using OMapR.Application.EntityAccess;

namespace OMapR.Api;


public class PersistenceProxy
{
    private readonly Core _core;


    public PersistenceProxy(Core core)
    {
        _core = core;
    }
    
    public IEntityAccess<TEntity> AccessEntity<TEntity>()
        where TEntity : new()
    {
        return _core.GetEntityAccess<TEntity>();
    }
}