using OMapR.Application;
using OMapR.Application.MappingBuilders;

namespace OMapR.Api;


public class PersistenceProxy : IPersistenceProxy
{
    private readonly ICore _core;

    
    public PersistenceProxy(ICore core)
    {
        _core = core;
    }


    public EntityMappingBuilder<TEntity> AddEntityMapping<TEntity>()
    {
        return new EntityMappingBuilder<TEntity>(_core);
    }
    
    public void ConnectToDb()
    {
        _core.ConnectToDb();
    }
}