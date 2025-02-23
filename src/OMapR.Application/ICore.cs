using OMapR.Application.EntityAccess;
using OMapR.Application.MappingConfigs;

namespace OMapR.Application;

public interface ICore
{
    IEntityConfig<TEntity> AddEntityConfig<TEntity>()
        where TEntity : new(); 
    
    IEntityAccess<TEntity> GetEntityAccess<TEntity>()
        where TEntity : new();
}