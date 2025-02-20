using OMapR.Application.MappingConfigs;

namespace OMapR.Api;


public interface IPersistenceProxy
{
    IEntityConfig<TEntity> AddEntityMapping<TEntity>();
    
    void ConnectToDb();
}