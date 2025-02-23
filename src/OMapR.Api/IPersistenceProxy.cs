using OMapR.Application.EntityAccess;
using OMapR.Application.MappingConfigs;

namespace OMapR.Api;


public interface IPersistenceProxy
{
    IEntityConfig<TEntity> AddEntityMapping<TEntity>()
        where TEntity : new();

    IEntityAccess<TEntity> AccessEntity<TEntity>()
        where TEntity : new();
}