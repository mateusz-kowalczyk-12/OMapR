using OMapR.Application;
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
    {
        return _core.AddEntityConfig<TEntity>();
    }
    
    public void ConnectToDb()
    {
        _core.ConnectToDb();
    }
}