using OMapR.Application.MappingBuilders;

namespace OMapR.Api;


public interface IPersistenceProxy
{
    EntityMappingBuilder<TEntity> AddEntityMapping<TEntity>();
    
    void ConnectToDb();
}